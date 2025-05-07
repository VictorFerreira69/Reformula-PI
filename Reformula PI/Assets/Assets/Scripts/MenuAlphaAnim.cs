using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class MenuAlphaAnim : MonoBehaviour
{
    public Image targetImage;
    public float minAlpha = 0.2f;
    public float maxAlpha = 1f;
    public float duration = 2f;

    private void Start()
    {
        StartAlphaLoop();
    }

    void StartAlphaLoop()
    {
      
        targetImage.DOFade(minAlpha, duration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
