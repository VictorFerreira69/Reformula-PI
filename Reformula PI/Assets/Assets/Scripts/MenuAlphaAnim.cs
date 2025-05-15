using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class MenuAlphaAnim : MonoBehaviour
{
    [Header("Imagem")]
    [SerializeField] private Image targetImage;

    [Header("Controle de transparência")]
    [SerializeField] private float minAlpha = 0.2f;
    [SerializeField] private float maxAlpha = 1f;

    [Header("Tempo da animação")]
    [SerializeField] private float duration = 2f;

    private void Start()
    {
        
          StartAlphaLoop();
    }


    //Inicia a animaçao
     private void StartAlphaLoop()
    {
        // Garante que a imagem começa no alpha máximo
        Color initialColor = targetImage.color;
        initialColor.a = maxAlpha;
        targetImage.color = initialColor;

        // Cria um loop
        targetImage.DOFade(minAlpha, duration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
