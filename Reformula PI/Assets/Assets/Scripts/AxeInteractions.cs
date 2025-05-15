using UnityEngine;

public class AxeInteractions : MonoBehaviour
{
    //  Arvore  que  vai  ser  cortada e colocando interface nela
    private ICutable interactableTarget;

    // Update chamado a cada frame
    void Update()
    {
        // Se o player  apertar "E" e tiver uma arvore para  corta na frente dele , ele executa o corte
        if (Input.GetKeyDown(KeyCode.E))
        {
           
            //Se o objeto nao for null so chama o Cut
            interactableTarget?.Cut();
        }
    }

    // Quando o machado entra na  colisão da arvore
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se a arvore  tem  interface ICutable
        if (other.TryGetComponent(out ICutable interactable))
        {
            // deixa a arvore brilhando)
            interactable.GetOutline();

            // Salva as arvores que podemos cortar
            interactableTarget = interactable;
        }
    }

    // Quando o machado sai da área da colisão da arvore
    private void OnTriggerExit(Collider other)
    {
        // Se ainda for um objeto cortável, remove o destaque
        if (other.TryGetComponent(out ICutable interactable))
        {
            interactable.LeaveOutline();

            //  referência para não cortar um objeto que não está mais por perto
            interactableTarget = null;
        }
    }
}
