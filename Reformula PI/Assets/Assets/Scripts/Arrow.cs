
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Arrow : MonoBehaviour
{
    private Rigidbody rb;
    private bool canRotate = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Gira a flecha na direção da velocidade 
        transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
    }

    void Update()
    {
        if (!canRotate) return;

        // Faz a flecha rotacionar de acordo com a direção do movimento
        transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Se o objeto  tiver IDamageable nele, vai causar  dano
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeHit();
            Destroy(gameObject); // Destroi a flecha
            return;
        }

        // Caso atinja o chão, a flecha para e desativa física
        if (other.CompareTag("Ground"))
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            canRotate = false;

            GetComponent<Collider>().enabled = false;
            rb.isKinematic = true;
            rb.useGravity = false;
        }
    }
}
