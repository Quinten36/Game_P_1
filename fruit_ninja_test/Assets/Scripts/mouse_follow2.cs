using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_follow2 : MonoBehaviour
{

    //private bool isPaused;
    //public GameObject objectWithScript;
    PauseMenu refScript;
 
 

    // Start is called before the first frame update
    void Start()
    {
        refScript = GameObject.Find("PauseMenuController").GetComponent<PauseMenu>();
        //GameObject objectWithScript;
        //objectWithScript.refScript;
        //objectWithScript.GetComponent<PauseMenu>();
        Cursor.visible = false;
        //objectWithScript.isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        //refScript = GetComponent<PauseMenu>();
        if (!refScript.isPaused) {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Vector3 pos2 = pos, 1;
            pos.z += 11;
            transform.position = pos;

            //Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Vector3 pos = r.GetPoint(1);

            //// Vector3 pos2 = pos, 1;
            //pos.z += 11;
            //transform.position = pos;
        }
    }
}
