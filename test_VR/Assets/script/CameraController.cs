using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [Header("Dev")]
    private bool doMovement = true;
    public Text test;
    public Text test2;
    private float leftRight;
    private float upDown = 65f;
    public float turnSpeed = 30f;
    [Header("Pan")]
    public float panSpeed = 30f;
    public float panBorderThickness = 15f;
    public float scrollSpeed = 5f;
    [Header("Border")]
    public float minYMove = -70f;
    public float maxYMove = -3f;
    public float minXMove = -60f;
    public float maxXMove = 15f;
    [Header("Movement")]
    public float movementZ;
    public float movementX;
    private float actualMoveY;
    private float actualMoveX;
    [Header("Camera")]
    public float minYCamera = 10f;
    public float maxYCamera = 105f;
    public float maxLeftRight = 45f;
    public float maxUpDown = 45f;

    private void Start()
    {
        upDown = -upDown;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.GameIsOver)
        {
            Debug.Log(GameManager.GameIsOver);
            this.enabled = false;
            return;
        }

        movementZ = transform.position.z;
        movementX = transform.position.x;

        // Dev tool
        if (Input.GetKeyDown(KeyCode.Escape))
            doMovement = !doMovement;
        if (!doMovement)
            return;

        /**** normal movement ****/
        
            //if (movementZ <= minYMove && movementZ >= maxYMove && movementX <= Mathf.Floor(maxXMove) && Mathf.Floor(movementX) >= minXMove) { 
                //forward
                //rightwards
                
            //}
        

        /**** scroll ****/
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minYCamera, maxYCamera);

        transform.position = pos;

        /**** rotate movement ****/

        // TEST ZONE
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        test.text = leftRight.ToString();
        test2.text = upDown.ToString();
        // TEST ZONE
        //links en rechts
        if (Input.GetKey(KeyCode.Mouse1) && Input.GetAxis("Horizontal") != 0 || Input.GetKey(KeyCode.Mouse1) && Input.GetAxis("Vertical") != 0)//Input.mousePosition.x <= panBorderThickness
        {
            leftRight += horizontal * Time.deltaTime * turnSpeed;
            upDown += vertical * Time.deltaTime * turnSpeed;
            //leftRight = Mathf.Clamp(leftRight, -maxLeftRight, maxLeftRight);
            transform.rotation = Quaternion.Euler(-upDown, leftRight, 0);
        }

    }
}
