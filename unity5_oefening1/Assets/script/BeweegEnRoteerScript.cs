using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeweegEnRoteerScript : MonoBehaviour
{

    public float snelheid = 0.1f;
    public float hoeksnelheid = 30f;
    float 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontaal = Input.GetAxis("Horizontal");
        float verticaal = Input.GetAxis("Vertical");

        transform.position += transform.forward * snelheid;

        transform.Rotate(-verticaal * hoeksnelheid, horizontaal * hoeksnelheid, 0);
    }
}
