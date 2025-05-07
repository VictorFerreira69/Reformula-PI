using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    IInteractable interactableTarget;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            interactableTarget?.Interact();
           
        }
    }

 

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IInteractable interactable))
        {
            interactableTarget = interactable;
           
        }
        if(other.TryGetComponent(out IOutlineable outlineable))
        {

            if(outlineable.IsOutlineable())
            {
                outlineable.GetOutline();
            }
            else
            {
                outlineable.LeaveOutline();
            }
           
           
          
           
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            interactableTarget = null;
     
        }
         if(other.TryGetComponent(out IOutlineable outlineable))
        {
            outlineable.LeaveOutline();
           
        }


    }
}
