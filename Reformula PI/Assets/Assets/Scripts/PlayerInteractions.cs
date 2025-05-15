using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    // objeto interagível
    IInteractable interactableTarget;

    
    void Update()
    {
        // Se o jogador apertar E
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            // Se tem objeto interagível perto, chama a interação
            interactableTarget?.Interact();
        }
    }

    // Quando o player entra em um trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto possui componente que implemente IInteractable
        if(other.TryGetComponent(out IInteractable interactable))
        {
            // Define esse objeto como  interagir
            interactableTarget = interactable;
        }

        //  o objeto possui IOutlineable
        if(other.TryGetComponent(out IOutlineable outlineable))
        {
            //  ativa o contorno
            if(outlineable.IsOutlineable())
            {
                outlineable.GetOutline();
            }
            else
            {
                // remove contorno 
                outlineable.LeaveOutline();
            }
        }
    }

    // Quando o player sai do trigger
    private void OnTriggerExit(Collider other)
    {
        // Se o objeto que o player saiu era interagível
        if (other.TryGetComponent(out IInteractable interactable))
        {
            interactableTarget = null;
        }

        // Se o objeto que o player saiu do outlineable,tira o contorno
        if(other.TryGetComponent(out IOutlineable outlineable))
        {
            outlineable.LeaveOutline();
        }
    }
}

