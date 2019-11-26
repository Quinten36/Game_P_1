using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_follow : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private float sliderX = 15;
    //private bool isPaused;
    //public GameObject objectWithScript;
    //PauseMenu refScript;



    // Start is called before the first frame update
    void Start()
    {
        //refScript = GameObject.Find("PauseMenuController").GetComponent<PauseMenu>();
        //GameObject objectWithScript;
        //objectWithScript.refScript;
        //objectWithScript.GetComponent<PauseMenu>();
        Cursor.visible = false;
        //objectWithScript.isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
      

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        if (Input.GetKey(KeyCode.E))
        {
            sliderX = 15;
            transform.eulerAngles = new Vector3(pitch, yaw, -sliderX);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            sliderX = 0;
            transform.eulerAngles = new Vector3(pitch, yaw, sliderX);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            sliderX = 15;
            transform.eulerAngles = new Vector3(pitch, yaw, sliderX);
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            sliderX = 0;
            transform.eulerAngles = new Vector3(pitch, yaw, -sliderX);
        }

    }
}
//refScript = GetComponent<PauseMenu>();
//if (!refScript.isPaused) {
//Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

// Vector3 pos2 = pos, 1;
//pos.z += 11;
// transform.position = pos;

//    Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);

//    Vector3 pos = r.GetPoint(1);
//print(pos);
//    Vector3 pos2 = pos;
////pos.z += 11;
//   // this.transform.position = pos;
//Debug.Log(pos);

//    var pos = Camera.main.WorldToScreenPoint(transform.position);
//    var dir = Input.mousePosition - pos;
//    var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
//    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);