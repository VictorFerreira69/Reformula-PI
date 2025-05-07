using Unity.VisualScripting;
using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable, IOutlineable
{

    int originalLayer;
    public bool IsOutlineable()
    {
        if(!GameManager.instance.canTakeItem)
        {
             return !onTableObj.activeSelf;
        }
       else
       {
            return true; 

       }
       
    }

    void Start()
    {
        originalLayer = gameObject.layer;
    }

    void SetLayerRecursively(GameObject obj, int newLayer)
    {
        obj.layer = newLayer;

       /* foreach (Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, newLayer);
        }*/
    }

    public void GetOutline()
    {
        SetLayerRecursively(gameObject, 6);
    }

    public void LeaveOutline()
    {
        SetLayerRecursively(gameObject, originalLayer)  ;
    }

    [SerializeField] GameObject onHandObj;
    [SerializeField] GameObject onTableObj;
    [SerializeField] PlayerHandState statePostInteraction;
    public void Interact()
    {

        if (onHandObj.activeSelf)
        {
            PlayerHandManager.instance.SwitchHandState(PlayerHandState.Nothing);
            onTableObj.SetActive(true);
            onHandObj.SetActive(false);
            GameManager.instance.canTakeItem = true;
            return;
        }

        if (!GameManager.instance.canTakeItem) return;
        PlayerHandManager.instance.SwitchHandState(statePostInteraction);
        onTableObj.SetActive(false);
        onHandObj.SetActive(true);
        GameManager.instance.canTakeItem = false;
        


    }

}
