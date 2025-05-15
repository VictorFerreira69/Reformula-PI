using UnityEngine;
using DG.Tweening;
public class BeTiny : MonoBehaviour
{
       [Header("Tempo até destruir o objeto")]
    [SerializeField] float timeToDestroy;

     void Start()
    {
        // Anima o scale do objeto
        transform.DOScale(new Vector3(0.01f, 0.01f, 0.01f), timeToDestroy)
            // Quando  acabar a animação, destrói o objeto
            .OnComplete(() =>
            {
                Destroy(gameObject);
            });
    }
}
