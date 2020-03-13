using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{

    private Rigidbody rb;

    Vector3 oldPos;
    Quaternion oldQ;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        oldPos = transform.position;
        oldQ = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("dfgdfg");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //zodat de bal niet meer kan draaien en bewegen
        rb.freezeRotation = true;
        rb.velocity = Vector3.zero;
        //resetten naar normale positie
        transform.position = oldPos;
        transform.rotation = oldQ;
        //zorgen dat de bal weer kan draaien
        rb.freezeRotation = false;
    }
}
