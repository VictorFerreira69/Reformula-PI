using UnityEngine;
using UnityEngine.UI;

public class Tree : MonoBehaviour, ICutable
{
    Transform posToBreak;
    bool canInteract;
    [SerializeField] int clicksToBreak;
    int originalLayer;

  
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         originalLayer = gameObject.layer;
        posToBreak = transform.GetChild(0);
        canInteract = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Cut()
    {

        if(!canInteract) return;    
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        canInteract = false;

        GameManager.instance.playerMov.cameraCanMove = false;
        GameManager.instance.playerMov.playerCanMove = false;

        GameManager.instance.player.position = posToBreak.position;

        Vector3 direction = (transform.position - GameManager.instance.player.position).normalized;
        direction.y = 0;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        GameManager.instance.player.rotation = targetRotation;
        SpawnButton();

        
        
    }
    void SpawnButton() 
    {
        Button buttonInstance = Instantiate(GameManager.instance.clickButtonInstance, GameManager.instance.canva.transform);
        RectTransform rectTransform = buttonInstance.GetComponent<RectTransform>(); 
        rectTransform.anchoredPosition = new Vector2(Random.Range(-460, 460), Random.Range(-224, 224));

        buttonInstance.onClick.AddListener(() =>
        {
            Destroy(buttonInstance.gameObject);
            clicksToBreak--;
            if(clicksToBreak <= 0 ) 
            {
                Destroy();

            }
            else { SpawnButton(); }
        });
        buttonInstance.gameObject.SetActive(true);

    }
    void Destroy() 
    {
       
        int z = transform.childCount;
        for (int i = 0; i < z; i++)
        {
            Transform child = transform.GetChild(0);
            GameObject childObj = child.gameObject;
            child.transform.parent = null;
            childObj.SetActive(true);
         
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameManager.instance.playerMov.cameraCanMove = true;
        GameManager.instance.playerMov.playerCanMove = true;

        QuestsManager.instance.TreeQuest();
        Destroy(gameObject);


    }
   
} 


