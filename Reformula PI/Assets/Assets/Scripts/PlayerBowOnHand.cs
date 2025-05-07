using System.Collections;
using UnityEngine;

public class PlayerBowOnHand : MonoBehaviour
{
    [SerializeField] float forceMultiplier;
    [SerializeField]float timer;

    [SerializeField]float maxForce;

    [SerializeField] float minForce;
    [SerializeField] float timeToMaxForce;
    [SerializeField] float timeToMinForce;

    [SerializeField] float cooldownToShoot;

    [SerializeField] GameObject arrowPrefab;
    Transform arrowInstancePosition;
    bool canShoot;
     
    void Start()
    {
        arrowInstancePosition = transform.GetChild(0);
        canShoot = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            
        
        }
        if (Input.GetMouseButton(0) && canShoot)
        {
            timer += Time.deltaTime; 



        }
   
        if (Input.GetMouseButtonUp(0) && canShoot)
        {
            
            Shoot();
        }
        void Shoot() 
        {

            GameObject arrowInstance = Instantiate(arrowPrefab, arrowInstancePosition.position, Quaternion.LookRotation(Camera.main.transform.forward));
            Rigidbody arrowInstanceRb = arrowInstance.GetComponent<Rigidbody>();
     
            arrowInstance.transform.rotation = Quaternion.LookRotation(arrowInstanceRb.linearVelocity, Vector3.up);
           
            timer = Mathf.Clamp(timer, timeToMinForce, timeToMaxForce);

            float force = (timer / timeToMaxForce) * forceMultiplier;
            Vector3 forceDirection = Camera.main.transform.forward * force;

            arrowInstanceRb.AddForce(forceDirection);
        
            timer = 0;

            StartCoroutine(ResetShootCooldown());


        }
        IEnumerator ResetShootCooldown()
        {
            canShoot = false;
            yield return new WaitForSeconds(cooldownToShoot);
            canShoot = true;
        }

    }
}
