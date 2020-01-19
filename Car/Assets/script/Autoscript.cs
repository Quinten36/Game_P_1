using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autoscript : MonoBehaviour
{
    [Header("Wheels")]
    public WheelCollider leftFront;
    public WheelCollider rightFront;
    public WheelCollider leftRear;
    public WheelCollider rightRear;

    [Header("Car specs")]
    public float maxEnginePower = 250;
    public float maxSteeringAngle = 30;

    [Header("Crash control")]
    public float resetTime = 5.0f;
    public float resetTimer = 0.0f;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            maxEnginePower = 500;
            if (Input.GetKey(KeyCode.X))
            {
                maxEnginePower = 750;
            }
        } else {
            maxEnginePower = 250;
        }
        float engine = maxEnginePower * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

       // Debug.Log(engine);

        leftFront.steerAngle = steering;
        rightFront.steerAngle = steering;

        leftRear.motorTorque = -engine;
        rightRear.motorTorque = -engine;

        ZetWiel(leftFront);
        ZetWiel(rightFront);
        ZetWiel(leftRear);
        ZetWiel(rightRear);

        Debug.Log(resetTimer);
        //Debug.Log(resetTime);

        crashControle();
    }

    void ZetWiel(WheelCollider collider)
    {
        Transform wheel = collider.transform.GetChild(0);
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        wheel.transform.position = position;
        wheel.transform.rotation = rotation;
    }

    private void crashControle()
    {
        if (transform.localEulerAngles.z > -89 && transform.localEulerAngles.z < -271 || transform.localEulerAngles.z > 89 && transform.localEulerAngles.z < 271)
        {
            resetTimer += Time.deltaTime;
        } 
        else
        {
            resetTimer = 0;
        }

        if (resetTimer > resetTime)
        {
            FlipCar();
        }
    }

    void FlipCar ()
    {
        transform.rotation = Quaternion.LookRotation(transform.forward);
        //transform.localPosition += Vector3.down * 1.5f;
        Vector3 oldpos = transform.position;
        oldpos.y += 3.0f;
        transform.position = oldpos;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        resetTimer = 0;
    }
}
