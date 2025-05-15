using UnityEngine;
using UnityEngine.UI;

public class Tree : MonoBehaviour, ICutable
{
    [Header("Configurações da Árvore")]
    [SerializeField] private int clicksToBreak; // Quantidade de cliques 

    private Transform posToBreak; // Posicionando o  player aonde ele teve  cortar
    private bool canInteract; // Evita múltiplas interações ao mesmo tempo
    private int originalLayer; // Layer principal da árvore

    

    void Start()
    {
        originalLayer = gameObject.layer; // Salva o layer principal
        posToBreak = transform.GetChild(0); // Posição do corte 
        canInteract = true;
    }

   
    public void GetOutline()
    {
        SetLayerRecursively(gameObject, 6); // Layer 6 = Outline
    }

    
   
   // Remove o outline restaurando o layer principal
    public void LeaveOutline()
    {
        SetLayerRecursively(gameObject, originalLayer);
    }

   
   
   // Função  que aplica layer em todos os filhos do objeto.
    void SetLayerRecursively(GameObject obj, int newLayer)
    {
        obj.layer = newLayer;
        foreach (Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }


  
//Inicia o processo de corte da árvore(travando a camera e nao podendo  ser mover)
    public void Cut()
    {
        if (!canInteract) return;

        // Ativa  o cursor pro playerclicar nos botões
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        canInteract = false;

        // Trava movimentação do player
        GameManager.instance.playerMov.cameraCanMove = false;
        GameManager.instance.playerMov.playerCanMove = false;

        // Coloca o player para a frente da árvore
        GameManager.instance.player.position = posToBreak.position;

        // Faz o player olhar para a  árvore
        Vector3 direction = (transform.position - GameManager.instance.player.position).normalized;
        direction.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        GameManager.instance.player.rotation = targetRotation;

        // Cria o primeiro botão(que vai ser o click)
        SpawnButton();
    }

    
   
    // vai cria  um botão em uma posição aleatória da tela  para ser o corte
    void SpawnButton()
    {
        Button buttonInstance = Instantiate(GameManager.instance.clickButtonInstance, GameManager.instance.canva.transform);
        RectTransform rectTransform = buttonInstance.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(Random.Range(-460, 460), Random.Range(-224, 224));

        // Ao clicar, o botão é destruído e conta um click de corte
        buttonInstance.onClick.AddListener(() =>
        {
            Destroy(buttonInstance.gameObject);
            clicksToBreak--;

            if (clicksToBreak <= 0)
            {
                DestroyTree();
            }
            else
            {
                SpawnButton(); // Cria outro botão se ainda nao destruio
            }
        });

        buttonInstance.gameObject.SetActive(true);
    }

   
    
    /// Destrói a árvore e o player pode ser mover denovo depois de destruir.
    void DestroyTree()
    {
        int totalChildren = transform.childCount;
        for (int i = 0; i < totalChildren; i++)
        {
            Transform child = transform.GetChild(0); //  pegamondo  o primeiro
            GameObject childObj = child.gameObject;
            child.SetParent(null); // Remove do objeto  principal
            childObj.SetActive(true); // Ativa para ele cair(come e uma arvore entao vai cair os troncos dela) 
        }

        // Volta para o controle do player
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameManager.instance.playerMov.cameraCanMove = true;
        GameManager.instance.playerMov.playerCanMove = true;

        // Chamando o método da missão 
        QuestsManager.instance.TreeQuest();

        // Remove a árvore 
        Destroy(gameObject);
    }
}


