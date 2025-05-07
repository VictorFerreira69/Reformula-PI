
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody rb;
    bool canRotate = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(rb.linearVelocity, Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {

        if (!canRotate) return;
        transform.rotation = Quaternion.LookRotation(rb.linearVelocity, Vector3.up);


    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Animal"))
        {
            QuestsManager.instance.AnimalKillQuest();    
            Destroy(gameObject);
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            canRotate = false;
            GetComponent<MeshCollider>().enabled = false;   
            rb.isKinematic = true;
            rb.useGravity = false;
            
        }
    }
}
