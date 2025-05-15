using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
   public Canvas canva;

    // Garante que só vai existir um GameManager ativo na cena
    public static GameManager instance;

   
    [Header("Referência ao Player")]
    public Transform player;
    [HideInInspector] public FirstPersonController playerMov;

  
    [Header("Interação com Itens")]
    public bool canTakeItem = true; // ver  ser o player pode pegar item
    public Button clickButtonInstance;


    [Header("Sistema de Diálogo")]
    public NpcDialogue npcDialogue; // codigo que esta  as falas do npc

    [SerializeField] private GameObject dialogueBg; // Dialgo
    [SerializeField] private TMP_Text dialogueText; // Texto do diálogo
    [SerializeField] private TypeWritterEffect typeWritter; // efeito da escrita do dialogo

    

    // chamado antes do Start
    void Awake()
    {
        instance = this; 
        playerMov = player.GetComponent<FirstPersonController>(); // Pega o codigo do player
        canTakeItem = true; //  o player pode pegar item
    }

   
    public void StartDialogue()
    {
        dialogueBg.SetActive(true); // Ativa o diálogo
        dialogueText.gameObject.SetActive(true); // Ativa o texto
        typeWritter.StopAllCoroutines(); //nenhuma escrita esteja em andamento
        StartCoroutine(typeWritter.Type(npcDialogue.dialogueLines[0])); //  escreveo primeiro dialogo do npc
    }

    
    public void FinishDialogue()
    {
        dialogueBg.SetActive(false); //  o dialogo se desativa da tela
        dialogueText.gameObject.SetActive(false); // Tira  o texto da tela
        npcDialogue.OnFinishToTalk.Invoke(); // Ativa o evento 
    }

    
    public void NextDialogue()
    {
        typeWritter.StopAllCoroutines(); // escrita atual
        StartCoroutine(typeWritter.Type(npcDialogue.dialogueLines[npcDialogue.where])); // Escreve o proximo dialogo
    }
}
