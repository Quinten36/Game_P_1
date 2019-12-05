using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeweegRoteer1 : MonoBehaviour
{

    public float speed = 0.1f;

    public Text test;
    public Text test2;

    float turn = 0f;

    float leftRight;
    float upDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float horizontaal = Input.GetAxis("Horizontal");
        float verticaal = Input.GetAxis("Vertical");

        transform.position += transform.forward * speed;
        
        turn += horizontaal;

        upDown += verticaal;
        upDown = Mathf.Clamp(upDown, -35 , 35);

        leftRight += horizontaal;
        leftRight = Mathf.Clamp(leftRight, -35 , 35);

        transform.rotation = Quaternion.Euler(-upDown, turn, -leftRight);

        test.text = horizontaal.ToString();
        test2.text = verticaal.ToString();

        if (horizontaal < 0.1 && horizontaal > -0.1) {
             if (leftRight < 0) {
                leftRight += 0.5f;
             } else if (leftRight > 0) {
                leftRight -= 0.5f;
             }
         } 
       
         if (verticaal == 0) {
             if (upDown < 0) {
                upDown += 0.5f;
             } else if (upDown > 0) {
                upDown -= 0.5f;
             }
         } 
    }
}



