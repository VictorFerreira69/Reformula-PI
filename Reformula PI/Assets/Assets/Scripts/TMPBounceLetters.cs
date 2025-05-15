using UnityEngine;
using TMPro;
using DG.Tweening;

public class TMPBounceLetters  : MonoBehaviour
{
    public TMP_Text tmpText; //componente TMP_Text 
    public float jumpHeight = 10f; // Altura do pulo
    public float jumpDuration = 1f; // Duração do  pulo 
    public float delayBetweenLetters = 0.1f; // Delay entre a animação
    public float rotationAmount = 5f; //  rotação na animação

    private TMP_TextInfo textInfo; // Info do texto 
    private Vector3[][] originalVertices; // Armazena os vértices

    void Start()
    {
        // Atualiza o mesh para garantir que os dados estao certos
        tmpText.ForceMeshUpdate();
        textInfo = tmpText.textInfo;

        // Guarda os vértices para cada mesh do texto
        originalVertices = new Vector3[textInfo.meshInfo.Length][];
        for (int i = 0; i < originalVertices.Length; i++)
            originalVertices[i] = tmpText.textInfo.meshInfo[i].vertices.Clone() as Vector3[];

        // Para cada letra visível do texto, inicia a coroutine
        for (int i = 0; i < textInfo.characterCount; i++)
        {
            int charIndex = i;
            if (!textInfo.characterInfo[charIndex].isVisible) continue;
            StartCoroutine(AnimateLetter(charIndex));
        }
    }

    // Coroutine que anima as letras
    System.Collections.IEnumerator AnimateLetter(int charIndex)
    {
        // Delay da letra
        yield return new WaitForSeconds(charIndex * delayBetweenLetters);

     
        int matIndex = textInfo.characterInfo[charIndex].materialReferenceIndex;
        int vertexIndex = textInfo.characterInfo[charIndex].vertexIndex;

        //  vértices do mesh dessa letra
        Vector3[] vertices = tmpText.textInfo.meshInfo[matIndex].vertices;
        
        //  vértices originais para poder animar 
        Vector3[] origVerts = new Vector3[4];
        for (int j = 0; j < 4; j++)
            origVerts[j] = originalVertices[matIndex][vertexIndex + j];

        float time = 0f;

        while (true) // Loop  para animar 
        {
            // Calcula o deslocamento vertical baseado em uma função seno para fazer a letra 
            float offsetY = Mathf.Sin(time * Mathf.PI * 2f / jumpDuration) * jumpHeight;
            
            // Calcula o ângulo da rotação 
            float angle = Mathf.Sin(time * Mathf.PI * 4f / jumpDuration) * rotationAmount;

            //rotação em torno do eixo Z
            Quaternion rot = Quaternion.Euler(0, 0, angle);

            // Aplica a rotação e o deslocamento vertical 
            for (int j = 0; j < 4; j++)
            {
                vertices[vertexIndex + j] = rot * origVerts[j] + new Vector3(0, offsetY, 0);
            }

            // Atualiza o mesh do texto 
            tmpText.UpdateVertexData(TMP_VertexDataUpdateFlags.Vertices);

            //  tempo e espera o próximo frame
            time += Time.deltaTime;
            yield return null;
        }
    }
}
