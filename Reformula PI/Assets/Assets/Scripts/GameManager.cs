using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public Transform player;
    [HideInInspector]public FirstPersonController playerMov;
    public Canvas canva;
    public bool canTakeItem;



    public Button clickButtonInstance;



    public NpcDialogue npcDialogue;
    [SerializeField] GameObject dialogueBg;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField]TypeWritterEffect typeWritter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
        playerMov = player.GetComponent<FirstPersonController>();
       
        canTakeItem = true;


    }

    public void StartDialogue() 
    {
        dialogueBg.SetActive(true);
        dialogueText.gameObject.SetActive(true);
        typeWritter.StopAllCoroutines();
        StartCoroutine(typeWritter.Type(npcDialogue.dialogueLines[0]));  


    }
    public void FinishDialogue()
    {
        dialogueBg.SetActive(false);
        dialogueText.gameObject.SetActive(false);
        npcDialogue.OnFinishToTalk.Invoke();    


    }
    public void NextDialogue()
    {

        typeWritter.StopAllCoroutines();
 StartCoroutine(typeWritter.Type(npcDialogue.dialogueLines[npcDialogue.where]));  


    }

}
