using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeweegScript : MonoBehaviour
{
    public float snelheid = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Xrichting = Input.GetAxis("Horizontal");
        float Zrichting = Input.GetAxis("Vertical");
        Vector3 pos = transform.position;
        pos.x += snelheid * Xrichting;
        pos.z += snelheid * Zrichting;
        transform.position = pos;
    }
}
