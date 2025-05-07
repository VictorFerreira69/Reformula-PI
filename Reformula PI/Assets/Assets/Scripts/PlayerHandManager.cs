using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
public enum PlayerHandState
{
    Nothing,
    Bow,
    Axe
}
public class PlayerHandManager : MonoBehaviour
{
    public UnityEvent OnNothing, OnBow, OnAxe;
    public static PlayerHandManager instance;
    Quaternion normalRotation;
    [SerializeField] Transform playerHandTransform;
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Quaternion normalRotation = playerHandTransform.localRotation;
        Vector3 starterPosition = playerHandTransform.localPosition;
        OnBow.AddListener(() => { playerHandTransform.localRotation = Quaternion.Euler(100.9f, 1.42f, -180f); playerHandTransform.position = new Vector3(0.5f + playerHandTransform.position.x, playerHandTransform.position.y + 0.3f, playerHandTransform.position.z); });
        OnNothing.AddListener(() => { playerHandTransform.localRotation = normalRotation; playerHandTransform.localPosition = starterPosition; });


    }


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
    public void SetPlayerHandScale(float scale) 
    {
     playerHandTransform.localScale = new Vector3(scale, scale, scale);



    }
    

}