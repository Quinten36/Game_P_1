using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private bool doMovement = true;
    public float panSpeed = 10f;
    public float panBorderThickness = 15f;
    private float leftRight;
    public float turnSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            doMovement = !doMovement;
        if (!doMovement)
            return;
        if (Input.GetKey(KeyCode.Mouse1) != true)
        {
            if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
            {
                //if (movementZ <= minYMove && movementZ >= maxYMove) {
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.Self);
                //}
            }
            //backwards
            if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
            {
                //if (movementZ <= minYMove && movementZ >= maxYMove) {
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.Self);
                //}
            }
            if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
            {
                //if (movementX <= maxXMove) {
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.Self);
                //}
            }
            //leftwards
            if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
            {
                //if (movementX >= minXMove) {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.Self);
                //}
            }
        }
        if (Input.GetKey(KeyCode.Mouse1) && Input.GetAxis("Horizontal") != 0 )//Input.mousePosition.x <= panBorderThickness
        {
            float horizontal = Input.GetAxis("Horizontal");
            leftRight += horizontal * Time.deltaTime * turnSpeed;
            //leftRight = Mathf.Clamp(leftRight, -maxLeftRight, maxLeftRight);
            transform.rotation = Quaternion.Euler(0, leftRight, 0);
        }

    }
}
