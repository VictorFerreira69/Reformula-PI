using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
//Os estados da mao
public enum PlayerHandState
{
    Nothing,
    Bow,
    Axe
}
public class PlayerHandManager : MonoBehaviour
{
    // Evento que troca o estado da mao
    public UnityEvent OnNothing, OnBow, OnAxe;

    
    public static PlayerHandManager instance;

    // Guarda a rotação da mao
    Quaternion normalRotation;

    //  transform da mão do jogador
    [SerializeField] Transform playerHandTransform;

   
    void Awake()
    {
        instance = this;
    }

    
    private void Start()
    {
        // Salva a rotação da mao
        Quaternion normalRotation = playerHandTransform.localRotation;
        // Salva a posição da mao
        Vector3 starterPosition = playerHandTransform.localPosition;

        // Evento para o estado do arco
        OnBow.AddListener(() => {
            // Altera a rotação do arco
            playerHandTransform.localRotation = Quaternion.Euler(100.9f, 1.42f, -180f);
            // Ajusta a posição 
            playerHandTransform.position = new Vector3(
                0.5f + playerHandTransform.position.x, 
                playerHandTransform.position.y + 0.3f, 
                playerHandTransform.position.z
            );
        });

        // Evento para o estado mão vazia
        OnNothing.AddListener(() => {
            // Volta para a rotação e posição inicial
            playerHandTransform.localRotation = normalRotation;
            playerHandTransform.localPosition = starterPosition;
        });
    }

    // Troca o estado da mão
    public void SwitchHandState(PlayerHandState state) 
    {
        switch(state)
        {
            case PlayerHandState.Nothing:
                OnNothing?.Invoke();
                break;
            case PlayerHandState.Bow:
                OnBow?.Invoke();
                break;
            case PlayerHandState.Axe:
                OnAxe?.Invoke();
                break;
        }
    }

    // Ajusta a escala da mão 
    public void SetPlayerHandScale(float scale) 
    {
        playerHandTransform.localScale = new Vector3(scale, scale, scale);
    }
}
