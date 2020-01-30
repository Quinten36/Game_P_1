using System.Collections;
using System.Collections.Generic;
//moveTo.cs
using UnityEngine;
using UnityEngine.AI;

public class goal : MonoBehaviour
{

    public Transform goalTo;

    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goalTo.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
