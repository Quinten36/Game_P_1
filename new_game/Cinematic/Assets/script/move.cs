using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    private Rigidbody rb;
    public float sliderX = 5;
    public GameObject cameraP;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKey(KeyCode.W))
            {
            this.transform.GetComponent<Rigidbody>().velocity = new Vector3(-10,0,0);
            }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.GetComponent<Rigidbody>().velocity = new Vector3(10, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -10);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 10);
        }
        if (Input.GetKey(KeyCode.E))
        {
            sliderX = 15;
            cameraP.transform.eulerAngles = new Vector3(sliderX, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            sliderX = 0;
            cameraP.transform.eulerAngles = new Vector3(sliderX, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            sliderX = 15;
            sliderX = -sliderX;
            transform.eulerAngles = new Vector3(sliderX, transform.eulerAngles.y, transform.eulerAngles.z);

            //Vector3 target = new Vector3(40, 2, 27);

            //transform.RotateAround(target, Vector3.left, 30 * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            sliderX = 0;
            transform.eulerAngles = new Vector3(sliderX, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
    // }
}
