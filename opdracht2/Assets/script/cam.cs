﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{

    public Transform volgobject;
    public float afstand = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (null != volgobject)
        {
            Vector3 pos = transform.position;
            pos.z = volgobject.position.z - afstand;
            transform.position = pos;
        }
    }
}
