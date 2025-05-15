using UnityEngine;

public class HandBob : MonoBehaviour
{
    [Header("Referência a mao do player ")]
    public Transform joint; 

    [Header("Movimentaçao com a mao")]
    public float bobSpeed = 10f; // Velocidade do balança da  mao 
    public Vector3 bobAmount = new Vector3(0.15f, 0.05f, 0f); // Intensidade do balanço

    [Header("Idle")]
    [SerializeField] float idleHandBobSpeed = 1f; // Velocidade do balanço parado

    private Vector3 jointOriginalPos; // Posição original da mao para voltar ao normal
    private float timer = 0; 
    private FirstPersonController controller; // Referência ao  codigo do player
    void Start()
    {
        // Pega o codigo  do jogador 
        controller = GetComponentInParent<FirstPersonController>();

        // Salva a posição original do objeto
        jointOriginalPos = joint.localPosition;
    }

    void Update()
    {
        HeadBob();
    }

    private void HeadBob()
    {
        // Se o jogador estiver se movendo
        if (controller.isWalking)
        {
            // Ajusta a velocidade do balanço
            if (controller.isSprinting)
            {
                //  acelera o balanço com a velocidade de correr
                timer += Time.deltaTime * (bobSpeed + controller.sprintSpeed);
            }
            else if (controller.isCrouched)
            {
                // se o player tiver agachado reduz a velocidade de movimentaçao
                timer += Time.deltaTime * (bobSpeed * controller.speedReduction);
            }
            else
            {
                // Andando normal
                timer += Time.deltaTime * bobSpeed;
            }

            // Aplica o movimento de balanço 
            joint.localPosition = new Vector3(
                jointOriginalPos.x + Mathf.Sin(timer) * bobAmount.x,
                jointOriginalPos.y + Mathf.Sin(timer) * bobAmount.y,
                jointOriginalPos.z + Mathf.Sin(timer) * bobAmount.z
            );
        }
        else
        {
            // Se o jogador está parado, continua um balanço 
            timer += Time.deltaTime;

            // Balanço idle
            joint.localPosition = new Vector3(
                jointOriginalPos.x + Mathf.Sin(timer) * bobAmount.x,
                jointOriginalPos.y + Mathf.Sin(timer) * bobAmount.y,
                jointOriginalPos.z + Mathf.Sin(timer) * bobAmount.z
            );
        }
    }
}
