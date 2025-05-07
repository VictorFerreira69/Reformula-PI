using UnityEngine;
using DG.Tweening;
public class ButtonAnim : MonoBehaviour
{
     private Tween scaleTween;

    public void PointerEnter()
    {
       
        scaleTween?.Kill();

        
        scaleTween = transform.DOScale(2f, 4f).SetEase(Ease.OutBack);
    }

    public void PointerExit()
    {
      
        scaleTween?.Kill();

        
        scaleTween = transform.DOScale(1.525f, 3f).SetEase(Ease.InOutQuad);
    }
}
