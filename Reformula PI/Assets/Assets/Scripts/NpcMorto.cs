using UnityEngine;

public class NpcMorto : MonoBehaviour, IInteractable, IOutlineable

{
    // Armazena a layer original do objeto
    int originalLayer;


    void Start()
    {
        // Salva a layer atual do objeto
        originalLayer = gameObject.layer;
    }

   
    // Define se o objeto pode receber outline
 
    public bool IsOutlineable()
    {
        return true;
    }

   
    /// Aplica a camada 6 no objeto e em todos os seus filhos para ativar o outline.
   
    public void GetOutline()
    {
        SetLayerRecursively(gameObject, 6); // 6 = outline
    }

   
    // Restaura a camada original do objeto e de todos os filhos
    
    public void LeaveOutline()
    {
        SetLayerRecursively(gameObject, originalLayer);
    }

    
    // Altera a layer de um objeto e todos os seus filhos
     void SetLayerRecursively(GameObject obj, int newLayer)
    {
        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }

    //  GameObject do jogador que será desativado na cutscene
    [SerializeField] private GameObject player;

    // cutscene que será ativada
    [SerializeField] private GameObject cutscene;

    // imagem do HUD normal do jogo
    [SerializeField] private GameObject imageGame;

    // imagem usada durante a cutscene
    [SerializeField] private GameObject imageCutscene;

    
    // Ação realizada ao interagir com o NPC morto.
  public void Interact()
    {
        player.SetActive(false);  // Desativa o jogador
        cutscene.SetActive(true); //Ativa a cutscene
        imageGame.SetActive(false); //oculta o hub do jogo
        imageCutscene.SetActive(true);//mostra a cutscene
    }
}
