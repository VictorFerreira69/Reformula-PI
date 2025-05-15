using UnityEngine;
using DG.Tweening;
public class ArrowAnimation : MonoBehaviour
{
    [Header("Animaçao")]
    public float moveDistance = 0.5f; //Distância que a seta vai subir e descer

 
    public float duration = 1f; //Tempo que vai levar para subir e descer

    private Vector3 startScale;

    void Start()
    {
        // Salva o tamanho  do objeto
        startScale = transform.localScale;

        // Anima o movimento no eixo Y 
        transform.DOMoveY(transform.position.y + moveDistance, duration)
            .SetLoops(-1, LoopType.Yoyo)  // Vai e volta
            .SetEase(Ease.InOutSine);   

        // Faz a escala no eixo X aumente e diminuir 
        transform.DOScaleX(startScale.x * 0.8f, duration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
            
    }
}
