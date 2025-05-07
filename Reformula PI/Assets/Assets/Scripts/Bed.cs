using UnityEngine;

public class Bed : MonoBehaviour, IInteractable, IOutlineable
{
    int originalLayer;
    bool canInteract;
    [SerializeField] GameObject aparecer;
        public bool IsOutlineable()
    {
        return canInteract;
    }   
    void Start()
    {
        originalLayer = gameObject.layer;
    }
    void SetLayerRecursively(GameObject obj, int newLayer)
    {
        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }

    public void GetOutline()
    {
       SetLayerRecursively(gameObject, 6);
    }
    public void LeaveOutline()
    {
        SetLayerRecursively(gameObject, originalLayer);
    }

    public void Interact()
    {
        aparecer.SetActive(true);
        GameManager.instance.canTakeItem = false;
    }
    void Update()
    {
        
    }
    public void ChangeStateToInteract(bool state)
    {
canInteract = state;


    }
}
