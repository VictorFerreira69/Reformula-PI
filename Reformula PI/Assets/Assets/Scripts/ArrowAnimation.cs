using UnityEngine;
using DG.Tweening;
public class ArrowAnimation : MonoBehaviour
{
   
    public  float moveDistance = 0.5f; 
    public  float duration = 1f; 
    Vector3 startScale;
    void Start()
    {
        startScale = transform.localScale; 

        transform.DOMoveY(transform.position.y + moveDistance, duration)
            .SetLoops(-1, LoopType.Yoyo); 

     
        transform.DOScaleX(startScale.x  - 100, duration)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
