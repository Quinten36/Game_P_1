using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beweeg : MonoBehaviour
{

    public float power;
    private Rigidbody rb;

    Vector3 oldPos;
    Quaternion oldQ;

    public float hoek;
    private float slow;


    // Start is called before the first frame update
    void Start()
    {
        power = 950;
        rb = GetComponent<Rigidbody>();

        oldPos = transform.position;
        oldQ = transform.rotation;
    }

    //charge. random hoek

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            hoek = Random.Range(90, -90);
            Debug.Log(hoek);
            rb.AddForce(-power, 0, hoek);
            rb.AddTorque(new Vector3(0, power, 0));
        }
        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    rb.AddForce(power - slow, 0, hoek);
        //}
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
