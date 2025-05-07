using UnityEngine;
using TMPro;
public class QuestsManager : MonoBehaviour
{
    [SerializeField] GameObject questObj;
    public static QuestsManager instance;

    [SerializeField] TMP_Text questText;

    public int animalNumber;
    public int tree;


    [SerializeField] GameObject npcPostAnimalQuest;
    [SerializeField] GameObject npcPostTree;


    private void Awake()
    {
        instance = this;
    }
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            questObj.SetActive(!questObj.activeSelf);
        }
       
    
    }
    public void StartQuest(string text) 
    {
        questText.text = text;
    
    
    }
    public void AnimalKillQuest() 
    {
        animalNumber--;
        if(animalNumber <= 0)
        {
            questText.text = "";
           npcPostAnimalQuest.SetActive(true);
            questObj.SetActive(false);
            StartQuest("Falar com o chefe da vila");
        }



    }
    public void TreeQuest()
    {
        tree--;
        if (tree <= 0)
        {
             
            questText.text = "";
            npcPostTree.SetActive(true);
            questObj.SetActive(false);
              StartQuest("Falar com o chefe da vila");
        }



    }

}
