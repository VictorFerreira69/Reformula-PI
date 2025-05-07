using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class TypeWritterEffect : MonoBehaviour
{
    public TMP_Text textA;
    public string finalText;
    [SerializeField] float cooldownForEachLetter;
    [SerializeField] GameObject cliqueProsseguir;
    // Start is called before the first frame update
    void Start()
    {
      
      
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            if (textA.text != finalText) 
            {
                GameManager.instance.StopAllCoroutines();
                textA.text = finalText;
                
                cliqueProsseguir.SetActive(true);
            }
            else
            {
                GameManager.instance.npcDialogue.NextDialogue();
             
        
            }
        }
    }
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
        cliqueProsseguir.SetActive(true);

    }


    

}