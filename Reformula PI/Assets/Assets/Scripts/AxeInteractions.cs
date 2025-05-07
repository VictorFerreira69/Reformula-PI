using UnityEngine;

public class AxeInteractions : MonoBehaviour
{
    ICutable interactableTarget;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interactableTarget?.Cut();

        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ICutable interactable))
        {
            interactable.GetOutline();
            interactableTarget = interactable;

        }
    


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ICutable interactable))
        {
             interactable.LeaveOutline();
            interactableTarget = null;

        }
      


    }
}
