using UnityEngine;
using UnityEngine.Events;
public class NpcDialogue : MonoBehaviour, IInteractable
{


    [TextArea(3, 10)]
    public string[] dialogueLines;
    [HideInInspector]public int where;
    public UnityEvent OnFinishToTalk;
    public UnityEvent OnStart;
    bool canInteract = true;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnStart.Invoke();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Interact()
    {
    
    if (!canInteract) return;
    canInteract = false;
        GameManager.instance.npcDialogue = this;
        where = 0;
        GameManager.instance.StartDialogue();



    }
    public void NextDialogue() 
    {
         
        where++;
        if(where >= dialogueLines.Length)
        {
            GameManager.instance.FinishDialogue();
            canInteract = true;
            where = 0;
            return;
        }
        GameManager.instance.NextDialogue();    

    }
}