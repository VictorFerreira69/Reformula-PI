using UnityEngine;
using UnityEngine.Events;
public class NpcDialogue : MonoBehaviour, IInteractable
{
    [Header("Linhas de Diálogo")]
    [TextArea(3, 10)]
    public string[] dialogueLines;

    [Header("Eventos de Diálogo")]
    public UnityEvent OnStart;
    public UnityEvent OnFinishToTalk;

   
    [HideInInspector]public int where;
    
    bool canInteract = true;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnStart.Invoke(); //Vendo se o evento esta atribuido
    }
//Iniciando o dialgo com o npc 
    public void Interact()
    {
    
    if (!canInteract) return;
    canInteract = false;
        GameManager.instance.npcDialogue = this;
        where = 0;
        GameManager.instance.StartDialogue();



    }
    //Indo pro proximo dialogo do npc 
    public void NextDialogue() 
    {
         
        where++;
        if(where >= dialogueLines.Length)
        {
            GameManager.instance.FinishDialogue(); //acaba o dialogo
            canInteract = true;
            where = 0;
            return;
        }
        GameManager.instance.NextDialogue();    

    }
}