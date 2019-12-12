using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beweeg : MonoBehaviour
{

    public float power;
    private Rigidbody rb;

    Vector3 oldPos;
    Quaternion oldQ;


    // Start is called before the first frame update
    void Start()
    {
        power = 350;
        rb = GetComponent<Rigidbody>();

        oldPos = transform.position;
        oldQ = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.forward * power);
            rb.AddTorque(new Vector3(0, power, 0));
        }

        if (Input.GetKeyDown(KeyCode.Escape))
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
}
