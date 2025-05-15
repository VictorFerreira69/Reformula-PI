using UnityEngine;
using DG.Tweening;
public class ButtonAnim : MonoBehaviour
{
    // Referência ao Tween 
    private Tween scaleTween;

    
    
    // Aumenta a escala do botão com uma animação.
    public void PointerEnter()
    {
        // Se já existe uma animação, cancela ela
        scaleTween?.Kill();

        // Cria uma nova animação de escala 
        scaleTween = transform
            .DOScale(2f, 4f) // Escala para o dobro em 4 segundos
            .SetEase(Ease.OutBack); // Ease com efeito elástico para fora
    }

    
    /// Chamado quando o ponteiro do botao
   public void PointerExit()
    {
        // Cancela qualquer animação anterior
        scaleTween?.Kill();

        // Cria uma nova animação para voltar à escala normal
        scaleTween = transform
            .DOScale(1.525f, 3f) // Volta um pouco para o tamanho que estava 
            .SetEase(Ease.InOutQuad); 
    }
}
