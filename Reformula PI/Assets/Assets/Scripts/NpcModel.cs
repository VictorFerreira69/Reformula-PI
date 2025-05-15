using UnityEngine;

public class NpcModel : MonoBehaviour, IOutlineable
{
    // Armazena a camada original do objeto
    private int originalLayer;

   
    private void Start()
    {
        // Salva a camada atual do objeto
        originalLayer = gameObject.layer;
    }

    //  indicando que esse objeto pode receber outline
    public bool IsOutlineable()
    {
        return true;
    }

    // Aplica o efeito de outline mudando a camada do objeto e de todos os seus filhos 
    public void GetOutline()
    {
        SetLayerRecursively(gameObject, 6); // 6 é a camada do outline
    }

    // Remove o outline restaurando a camada original dos objetos
    public void LeaveOutline()
    {
        SetLayerRecursively(gameObject, originalLayer);
    }

    // Altera a camada de um objeto e de todos os seus filhos
    private void SetLayerRecursively(GameObject obj, int newLayer)
    {
        // Verifica se o objeto não é nulo
        if (obj == null) return;

        // Altera a camada do objeto 
        obj.layer = newLayer;

        // Repete o processo para todos os filhos do objeto
        foreach (Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }
}
