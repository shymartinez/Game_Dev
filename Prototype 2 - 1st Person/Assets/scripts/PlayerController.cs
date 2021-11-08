using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("stats")]
    public int curHP;
    public int maxHP;
    [Header("Movement")]
    public float moveSpeed; // How fast player moves 
    public float jumpForce; // How high the player jumps 
   [Header("Camera")]
    public float lookSensitivity; // Mouse movement sensitivity 
    public float maxLookx;  // Lowest down we can look 
    public float minLookx; // Highest up we can look 
    private float rotx;  // Current x rotation of the camera 
    [Header("Components")]
    private Camera cam;
    private Rigidbody rb;

    private Weapon weapon;

    void Awake()
    {
        // Get components 
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();

        weapon = GetComponent<Weapon>();

        // disable cursor 
        Cursor.LockState = Cursor.LockMode.Locked;
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
            if(weapon.CanShoot())
                weapon.Shoot();
        }

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
    public void TakeDamage(int damage)
    {
        curHP -= damage;
        
        if(curHP <= 0)
            die();
    }
    void Die()
    {
        print(" ur ded ")
    }
}
