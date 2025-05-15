using UnityEngine;

public class Bed : MonoBehaviour, IInteractable, IOutlineable
{
   
    private int originalLayer; // Camada original do objeto 

   
    private bool canInteract; // Ver se o jogador pode interagir com a cama

    [Header("Referências")]
   [SerializeField] GameObject aparecer; //O que a vai parecer quando o jogador interagir com a cama

    
    /// Indica se o objeto pode ser contornado com outline 
  public bool IsOutlineable()
    {
        return canInteract;
    }

    void Start()
    {
        // Guarda a camada original da cama 
        originalLayer = gameObject.layer;
    }

    
    /// Altera a layer  do objeto e de todos os seus filhos
    void SetLayerRecursively(GameObject obj, int newLayer)
    {
        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }

    
    // Ativa o outline 
    public void GetOutline()
    {
        SetLayerRecursively(gameObject, 6); // Layer 6: Outline
    }

    
    // Remove o outline e retorna à layer original
    public void LeaveOutline()
    {
        SetLayerRecursively(gameObject, originalLayer);
    }

 // interagir com a cama  e bloqueia  para nao poder pegar itens
 public void Interact()
    {
        aparecer.SetActive(true);
        GameManager.instance.canTakeItem = false;
    }
  // Permite ativar ou desativar a interaçao com a cama
    public void ChangeStateToInteract(bool state)
    {
        canInteract = state;
    }
}