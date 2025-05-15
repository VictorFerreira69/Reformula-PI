using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class TypeWritterEffect : MonoBehaviour
{
    public TMP_Text textA; // texto TMP  
    public string finalText; // Texto completo 
    [SerializeField] float cooldownForEachLetter; // Tempo entre cada letra
    [SerializeField] GameObject cliqueProsseguir; // Objeto para aparecer quando a escrita 

    void Start()
    {
        // Nada é feito aqui no momento
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Se o jogador clicar  com o maouse
        {
            if (textA.text != finalText) // e o texto ainda está sendo digitado
            {
                GameManager.instance.StopAllCoroutines(); // Para a digitação atual
                textA.text = finalText; //  texto completo 
                cliqueProsseguir.SetActive(true); //  botão de continuar
            }
            else
            {
                GameManager.instance.npcDialogue.NextDialogue(); // próximo diálogo
            }
        }
    }

    // Coroutine que escreve o texto  
    public IEnumerator Type(string text)
    {
        finalText = text;
        textA.text = "";
        cliqueProsseguir.SetActive(false);

        char[] letters = text.ToCharArray();
        for (int i = 0; i < letters.Length; i++)
        {
            textA.text += letters[i];
            yield return new WaitForSeconds(cooldownForEachLetter);
        }

        cliqueProsseguir.SetActive(true); // Mostra o botão 
    }
}