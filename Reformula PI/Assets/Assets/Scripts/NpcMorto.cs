using UnityEngine;

public class NpcMorto : MonoBehaviour, IInteractable, IOutlineable
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

 
  
    [SerializeField] private GameObject player;
    
    [SerializeField] private GameObject cutscene;
    
    [SerializeField] private GameObject imageGame;
    
    [SerializeField] private GameObject imageCutscene;
    public void Interact()
    {
    
        player.SetActive(false);
        cutscene.SetActive(true);
        imageGame.SetActive(false);
        imageCutscene.SetActive(true);


    }
   
}
