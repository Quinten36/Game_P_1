using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public static float speed = 2f;

    private Transform target;
    private int waypointIndex = 0;
    private Vector3 dir;
    private Vector3 oldPos;

    private Rigidbody rb;

    public GameObject Player;

    void Start ()
    {
        target = Waypoints.points[0];
        rb = GetComponent<Rigidbody>();
        oldPos = transform.position;
        //Vector3 pos = Vector3(-3, 0.7, 6);
        //Instantiate(Player, pos);
        
    }

    //zorgen dat ik kan meten hoeveel er tussen de grond en de player zit. en dan pas springen.
    //als de player tag death hit moet hij wordenterug gezet naar pos

    void Update()
    {
        dir = target.position - transform.position;
        // Debug.Log(dir);
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        if (transform.position.y <= 0.8f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(0, 200, 0);
                Debug.Log("spring");
            }
        }

    }

    private void OnCollisionEnter(Collision other)
    {

    }

    void GetNextWaypoint ()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            waypointIndex = 0;
            control.score++;
            speed += 0.75f;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "death")
        {
            transform.position = oldPos;
            waypointIndex = 0;
            control.life--;
            target = Waypoints.points[waypointIndex];
            //Waypoints.points[waypointIndex] = Waypoints.points[waypointIndex] ;
            Debug.Log("death");
        }
    }
}
