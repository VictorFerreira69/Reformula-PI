using UnityEngine;

public class NpcModel : MonoBehaviour, IOutlineable
{
    int originalLayer;
    public bool IsOutlineable()
    {
        return true;
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
}
