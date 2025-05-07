using UnityEngine;
using DG.Tweening;
public class BeTiny : MonoBehaviour
{
    [SerializeField] float timeToDestroy;

    void Start()
    {
        transform.DOScale(new Vector3(0.01f, 0.01f, 0.01f), timeToDestroy).OnComplete(() =>
            {
        
        Destroy(gameObject);

            });
    }

  
}
