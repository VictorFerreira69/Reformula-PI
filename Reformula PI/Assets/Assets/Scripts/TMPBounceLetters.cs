using UnityEngine;
using TMPro;
using DG.Tweening;

public class TMPBounceLetters  : MonoBehaviour
{
    public TMP_Text tmpText;
    public float jumpHeight = 10f;
    public float jumpDuration = 1f;
    public float delayBetweenLetters = 0.1f;
    public float rotationAmount = 5f;

    private TMP_TextInfo textInfo;
    private Vector3[][] originalVertices;

    void Start()
    {
        tmpText.ForceMeshUpdate();
        textInfo = tmpText.textInfo;

   
        originalVertices = new Vector3[textInfo.meshInfo.Length][];
        for (int i = 0; i < originalVertices.Length; i++)
            originalVertices[i] = tmpText.textInfo.meshInfo[i].vertices.Clone() as Vector3[];

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            int charIndex = i;
            if (!textInfo.characterInfo[charIndex].isVisible) continue;

            StartCoroutine(AnimateLetter(charIndex));
        }
    }

    System.Collections.IEnumerator AnimateLetter(int charIndex)
    {
        yield return new WaitForSeconds(charIndex * delayBetweenLetters);

        int matIndex = textInfo.characterInfo[charIndex].materialReferenceIndex;
        int vertexIndex = textInfo.characterInfo[charIndex].vertexIndex;

        Vector3[] vertices = tmpText.textInfo.meshInfo[matIndex].vertices;
        Vector3[] origVerts = new Vector3[4];
        for (int j = 0; j < 4; j++)
            origVerts[j] = originalVertices[matIndex][vertexIndex + j];

        float time = 0f;

        while (true)
        {
            float offsetY = Mathf.Sin(time * Mathf.PI * 2f / jumpDuration) * jumpHeight;
            float angle = Mathf.Sin(time * Mathf.PI * 4f / jumpDuration) * rotationAmount;

            Quaternion rot = Quaternion.Euler(0, 0, angle);

            for (int j = 0; j < 4; j++)
            {
                vertices[vertexIndex + j] = rot * origVerts[j] + new Vector3(0, offsetY, 0);
            }

            tmpText.UpdateVertexData(TMP_VertexDataUpdateFlags.Vertices);

            time += Time.deltaTime;
            yield return null;
        }
    }
}
