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

    void Start()
    {
        //Initialize the UI
        GameUI.instance.UpdateHealthBar(curHP,maxHP);
        GameUI.instance.UpdateScoreText(0);
        GameUI.instance.UpdateAmmoText(weapons.curAmmo, weapons.maxAmmo); 
    }
    public void TakeDamage(int damage)
    {
        curHP -= damage;
        
        if(curHP <= 0)
            Die();

        GameUI.instance.UpdateHealthBar(curHP, maxHP);
    }
    void Die()
    {
        GameManager.instance.LoseGame();
    }

    //Update is called once per frame
    void Update()
    {
        //Dont do anything when game is paused
        if(GameManager.instance.gamePaused == true)
            return;
        
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
        if(Physics.Raycast(ray, 1.1f))
        {
              rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse );
        }
    }

    void CamLook()
    {  
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity; 
        // Clamp the vertical rotation of the camera 
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
         // Applying rotation to camera
        cam.transform.localRotation = Quaternion.Euler(-rotX,0,0);
        transform.eulerAngles += Vector3.up * y;
     }
    public void GiveHealth(int amountToGive)
    {
        curHP = Mathf.Clamp(curHP + amountToGive, 0, maxHP);
        GameUI.instance.UpdateHealthBar(curHP, maxHP);
    }

    public void GiveAmmo(int amountToGive)
    {
        weapons.curAmmo = Mathf.Clamp(weapons.curAmmo + amountToGive, 0, weapons.maxAmmo);
        GameUI.instance.UpdateAmmoText(weapons.curAmmo ,weapons.maxAmmo);
    }
}