using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    public Transform target, enemyGraphics;
    public float speed = 10.0f;
    public float nextWayPointDistance = 3.0f;
    public float pathUpdateInterval = 0.5f;
    public float targetInterval = 0.5f;

    Path path;

    int currentWaypoint = 0;

    Seeker seeker;

    Rigidbody2D rb;

    private GameObject[] players;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        enemyGraphics = gameObject.transform.GetChild(0).gameObject.transform;


        InvokeRepeating("UpdatePath", 0f, pathUpdateInterval);
        InvokeRepeating("UpdatePlayers", 0f, targetInterval);
    }

    //Update path that leads to next target
    void UpdatePath()
    {
        if(seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    public void UpdatePlayers(){    //finds all players in game. Should be called when a player respawns or gets killed. 
        players = GameObject.FindGameObjectsWithTag("Ship");

        float distanceToPlayer = Mathf.Infinity;
        GameObject closestPlayer = null;
        foreach(GameObject player in players)
        {   //finds the closest player to chase after
            float tempDistance = Mathf.Abs(Vector2.Distance(rb.position, player.transform.position));
            if(tempDistance < distanceToPlayer)
            {
                distanceToPlayer = tempDistance;
                closestPlayer = player; 
            }
        }
        if(target != closestPlayer.transform){
            target = closestPlayer.transform;
        }
        
    }

    //when a path node is reached, the path is updated to the successor
    void OnPathComplete(Path nextPath)
    {
        if(!nextPath.error)
        {
            path = nextPath;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {   //make sure path is made
        if(path == null)
            return;

        //determine if end of path is reached
        if(currentWaypoint >= path.vectorPath.Count)
            return;

        //Get direction to travel
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        
        //calculate force to apply
        Vector2 force = direction * speed * Time.deltaTime;

        //apply force to the enemy - slowed by drag
        rb.AddForce(force);

        //find distance from enemy to the current waypoint
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        //if current waypoint is passed, iterate waypoint 
        if(distance < nextWayPointDistance)
        {
            ++currentWaypoint;
        }

        //face the direction of force if changing waypoint
        else if(force.x > (speed * Time.deltaTime / 5))
        {
            enemyGraphics.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (force.x < (-speed * Time.deltaTime / 5))
        {
            enemyGraphics.localScale = new Vector3(-1f, 1f, 1f);
        }

    }
    
}
