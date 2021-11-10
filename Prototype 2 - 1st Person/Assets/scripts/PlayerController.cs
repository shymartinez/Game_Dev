using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    [Header("Movement")]
    public float moveSpeed; // How fast player moves 
    public float jumpForce; // How high the player jumps 
   [Header("Camera")]
    public float lookSensitivity; // Mouse movement sensitivity 
    public float maxLookX;  // Lowest down we can look 
    public float minLookX; // Highest up we can look 
    private float rotX;  // Current x rotation of the camera 
    [Header("Components")]
    private Camera cam;
    private Rigidbody rb;
    private Weapons weapons;

    [Header("stats")]
    public int curHP;
    public int maxHP;

    void Awake()
    {
        // Get components 
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        weapons = GetComponent<Weapons>();

        // disable cursor 
        Cursor.lockState = CursorLockMode.Locked;
    }

        // Update is called once per frame
    void Update()
    {
        Move();
        CamLook();
        // jump button 
        if(Input.GetButtonDown("Jump"))
            Jump();
        // fire button
        if(Input.GetButton("Fire1"))
        {
            if(weapons.CanShoot())
            {
                 weapons.Shoot();
            }
        }

    }

    void Move()
    {  
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;
        
        //face direction of camera
        Vector3 dir = transform.right * x + transform.forward * z;
        // jump direction
        dir.y = rb.velocity.y;
        // apply direction to camera movement
        rb.velocity = dir;
    }

    void Jump()
    {  
        Ray ray = new Ray(transform.position, Vector3.down);
        // Check Ray length to jump
        if(Physics.Raycast(ray, 1.1f))
        {
              rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse );
        }
    }

    private void CamLook()
    {  
        float y = Input.GetAxis("Mouse X")  * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity; 
        // Clamp the vertical rotation of the camera 
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
         // Applying rotation to camera
        cam.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
     }
    public void TakeDamage(int damage)
    {
        curHP -= damage;
        
        if(curHP <= 0)
            Die();
    }
    void Die()
    {
        print(" ur ded ");
    }
}
