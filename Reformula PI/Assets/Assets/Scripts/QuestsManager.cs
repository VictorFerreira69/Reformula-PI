using UnityEngine;
using TMPro;
public class QuestsManager : MonoBehaviour
 {
         [Header("Referências Gerais")]
    [SerializeField] private GameObject questObj;//Game object que mostra missao que o player esta
    [SerializeField] private TMP_Text questText; // Texto da missão

    [Header("Dependências de Missões")]
    [SerializeField] private GameObject npcPostAnimalQuest;  // NPC atuliza a missao após matar todos os animais
    [SerializeField] private GameObject npcPostTree;  // NPC  atuliza a missao após cortar todas as árvores

    [Header("Progressos de Missões")]
    public int animalNumber; // Quantidade de animais para matar
    public int tree;  // Quantidade de árvores  para cortar

    public static QuestsManager instance;

   private void Awake()
    {
       
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        // Tecla T ativa e para desativa a UI
        if (Input.GetKeyDown(KeyCode.T))
        {
            questObj.SetActive(!questObj.activeSelf);
        }
    }

  
   
     // Inicia uma nova missão 
    public void StartQuest(string text)
    {
        questText.text = text;
        questObj.SetActive(true);
    }

   
     // Chamada sempre que um animal for morto.
    // Atualiza o progresso e ativa o próximo objetivo quando completar.
   
    public void AnimalKillQuest()
    {
        animalNumber--;

        if (animalNumber <= 0)
        {
            questText.text = "";
            npcPostAnimalQuest.SetActive(true); 
            questObj.SetActive(false);
            StartQuest("Falar com o chefe da vila"); // Atualiza a missão
        }
    }

    
    // Chamada sempre que uma árvore for cortada.
    // Atualiza o progresso e ativa o próximo objetivo quando completar.
    
    public void TreeQuest()
    {
        tree--;

        if (tree <= 0)
        {
            questText.text = "";
            npcPostTree.SetActive(true); 
            questObj.SetActive(false);
            StartQuest("Falar com o chefe da vila"); // Atualiza a missão
        }
    }
}