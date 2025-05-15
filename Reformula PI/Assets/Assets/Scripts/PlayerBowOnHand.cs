using System.Collections;
using UnityEngine;

public class PlayerBowOnHand : MonoBehaviour
{
    [Header("Força do Tiro")]
    [SerializeField] private float forceMultiplier; //  força para atira a flecha
    [SerializeField] private float timeToMaxForce;    // Tempo máximo para  a força máxima
    [SerializeField] private float timeToMinForce;   // Tempo mínimo para força mínima
    [SerializeField] private float maxForce;   // Força máxima 
    [SerializeField] private float minForce;   // Força mínima

    [Header(" Tiro")]
    [SerializeField] private float cooldownToShoot;   // cooldown entre tiros
    [SerializeField] private GameObject arrowPrefab;   // Prefab da flecha

    private Transform arrowInstancePosition;  // Posição onde a flecha será instanciada
    private bool canShoot = true;  // Controle para saber se pode atirar
    private float timer = 0f;   // Tempo para medir o carregamento do tiro

    void Start()
    {
        // Pega a posição para spawnar a flecha
        arrowInstancePosition = transform.GetChild(0);
        canShoot = true;
    }

    void Update()
    {
        // o botão do mouse foi pressionado
        if (Input.GetMouseButtonDown(0))
        {
            timer = 0f;
        }

        // Enquanto o botão do mouse estiver pressionado, acumula o tempo no timer
        if (Input.GetMouseButton(0) && canShoot)
        {
            timer += Time.deltaTime;
        }

        // Quando o botão do mouse for solto,executa o tiro
        if (Input.GetMouseButtonUp(0) && canShoot)
        {
            Shoot();
        }
    }

    // Método que instancia a flecha 
    private void Shoot()
    {
     // garantir que fique entre os tempos mínimo e máximo
        timer = Mathf.Clamp(timer, timeToMinForce, timeToMaxForce);

        // Calcula a força com o tempo de carregamento
        float force = (timer / timeToMaxForce) * forceMultiplier;

        // Instancia a flecha na posição definida com a rotação da câmera
        GameObject arrowInstance = Instantiate(arrowPrefab, arrowInstancePosition.position, Quaternion.LookRotation(Camera.main.transform.forward));

        //  Rigidbody da flecha para aplicar a força
        Rigidbody arrowRb = arrowInstance.GetComponent<Rigidbody>();

        //   força na direção que a câmera está olhando
        Vector3 forceDirection = Camera.main.transform.forward * force;
        arrowRb.AddForce(forceDirection, ForceMode.Impulse);

        // tempo para o tiro
        timer = 0f;

        // Começa a coroutine 
        StartCoroutine(ResetShootCooldown());
    }

    // Coroutine controlar o cooldown dos tiros
    private IEnumerator ResetShootCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(cooldownToShoot);
        canShoot = true;
    }
}