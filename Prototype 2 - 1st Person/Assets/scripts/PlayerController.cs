using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement 
    public float moveSpeed; // How fast player moves 
    public float jumpForce; // How high the player jumps 
    // Camera 
    public float lookSensitivity; // Mouse movement sensitivity 
    public float maxLookx;  // Lowest down we can look 
    public float minLookx; // Highest up we can look 
    private float rotx;  // Current x rotation of the camera 
    //components 
    private Camera cam;
    private Rigidbody rb;

    void Awake()
    {
        // Get components 
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

        // Update is called once per frame
    void Update()
    {
        Move();
        CamLook();
        if(Input.GetButtonDown("Jump"))
            Jump();
            
    }
    void Move()
    {  
         // Get Keyboard Input with moveSpeed
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;
        // Applying movement to the rigidbody
        Vector3 dir = transform.right * x + transform.forward * z;
        // jump direction
        dir.y = rb.velocity.y;
        // apply direction to camera movement
        rb.velocity = dir;
    }
    void Jump()
    {  
         //Cast ray to ground 
        Ray ray = new Ray(transform.position, Vector3.down);
        // Check Ray length to jump
        if(Physics.Raycast(ray, 1.1f))
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse );
    }
    private void CamLook()
    {  
         // get mouse input for to look around with mouse 
        float y = Input.GetAxis("Mouse X")  * lookSensitivity;
        rotx += Input.GetAxis("Mouse Y") * lookSensitivity; 

        // Clamp the vertical rotation of the camera 
        rotx = Mathf.Clamp(rotx, minLookx, maxLookx);

        // Applying rotation to camera
        cam.transform.localRotation = Quaternion.Euler(-rotx, 0, 0);
        transform.eulerAngles += Vector3.up * y;
     }
}
