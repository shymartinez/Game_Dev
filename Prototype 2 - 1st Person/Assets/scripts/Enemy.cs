using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public int curHP, maxHP, ScoreToGive;

    [Header("Movement")]
    public float moveSpeed, attackRange, yPathOffset;

    private List<Vector3> path;

    private Weapon weapon 
    private Gameobject target; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        // Gather components 
        weapon = GetComponent<Weapon>();
        target = FindObjectOfType<PlayerController>().gameObject;

    }

    void UpdatePath(
    {
        // Calculate path to Target
        NavMeshPath navMeshPath = new NavMeshPath();

        NavMesh.CalculatePath(transform.position, target.transform.positon, NaveMesh.AllAreas, navMeshPath);
        
        // save caalculated path to the list 
        path = navMeshPath.corners.ToList();
    }
    void ChaseTarget()
    {
        if(path.Count == 0)
            return 
        
        // Move towards the closest path
        transfrom.positon = Vector3.MoveTowards(transform.positon, path[0] + mew Vector3(0, yPathOffset, 0) moveSpeed * Time.deltaTime;

        if(transform.position == path[0] + )
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
