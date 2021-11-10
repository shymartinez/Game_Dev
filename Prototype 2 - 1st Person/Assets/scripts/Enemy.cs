using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Enemy : MonoBehaviour
{

    [Header("Stats")]
    public int curHP;
    public int maxHP;
    public int ScoreToGive;

    [Header("Movement")]
    public float moveSpeed;
    public float attackRange; 
    
    public float yPathOffset;


    private List<Vector3> path;

    private Weapons weapons; 
    public GameObject target; 

    private Rigidbody rb;
    
    
    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;

        // Gather components 
        weapons = GetComponent<Weapons>();
        target = FindObjectOfType<PlayerController>().gameObject;
        rb = GetComponent<Rigidbody>();

        InvokeRepeating("UpdatePath", 0.0f, 0.5f);

    }

    void UpdatePath()
    {
        // Calculate path to Target
        NavMeshPath navMeshPath = new NavMeshPath();
         NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);
        
        // save calculated path to the list 
        path = navMeshPath.corners.ToList();
    }

    void ChaseTarget()
    {
        if(path.Count == 0)
            return;
        
        // Move towards the closest path
        transform.position = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0, yPathOffset, 0), moveSpeed * Time.deltaTime);

        if(transform.position == path[0] + new Vector3(0, yPathOffset, 0));
            path.RemoveAt(0);  
    }

    public void TakeDamage(int damage)
    {
        curHP -= damage;

        if(curHP <= 0);
            Die();
    }

    void Die()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.AddForce(Vector3.back * 10, ForceMode.Impulse);
        rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        Destroy(gameObject,1);
    }

    // Update is called once per frame
    void Update()
    {
       // Look at Target
       Vector3 dir = (target.transform.position - transform.position).normalized;
       float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg; 

       transform.eulerAngles = Vector3.up * angle; 

       // get distance from enemy to player/target
       float dist = Vector3.Distance(transform.position, target.transform.position);

       if(dist <= attackRange)
       {
           if(weapons.CanShoot())
                weapons.Shoot();
       }
       else
       {
           ChaseTarget();
       }
    }
}
