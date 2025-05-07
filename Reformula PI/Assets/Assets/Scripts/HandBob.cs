using UnityEngine;

public class HandBob : MonoBehaviour
{
 
    public Transform joint;
    public float bobSpeed = 10f;
    public Vector3 bobAmount = new Vector3(.15f, .05f, 0f);
    private Vector3 jointOriginalPos;
    private float timer = 0;
    FirstPersonController controller;
    [SerializeField] float idleHandBobSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponentInParent<FirstPersonController>();
        jointOriginalPos = joint.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
       
            HeadBob();
       
    }
    private void HeadBob()
    {
        if (controller.isWalking)
        {
          
            if (controller.isSprinting)
            {
                timer += Time.deltaTime * (bobSpeed + controller.sprintSpeed);
            }
           
            else if (controller.isCrouched)
            {
                timer += Time.deltaTime * (bobSpeed * controller.speedReduction);
            }
            
            else
            {
                timer += Time.deltaTime * bobSpeed;
            }
          
            joint.localPosition = new Vector3(jointOriginalPos.x + Mathf.Sin(timer) * bobAmount.x, jointOriginalPos.y + Mathf.Sin(timer) * bobAmount.y, jointOriginalPos.z + Mathf.Sin(timer) * bobAmount.z);
        }
        else
        {
          
            if(timer > idleHandBobSpeed ) 
            {
                timer -= Time.deltaTime;

            }
            else 
            {
                timer += Time.deltaTime;
            }
                //joint.localPosition = new Vector3(Mathf.Lerp(joint.localPosition.x, jointOriginalPos.x, Time.deltaTime * bobSpeed), Mathf.Lerp(joint.localPosition.y, jointOriginalPos.y, Time.deltaTime * bobSpeed), Mathf.Lerp(joint.localPosition.z, jointOriginalPos.z, Time.deltaTime * bobSpeed));
                joint.localPosition = new Vector3(jointOriginalPos.x + Mathf.Sin(timer) * bobAmount.x, jointOriginalPos.y + Mathf.Sin(timer) * bobAmount.y, jointOriginalPos.z + Mathf.Sin(timer) * bobAmount.z);
        }
    }
}
