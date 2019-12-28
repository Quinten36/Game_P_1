﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // een manier om een script public te maken van van allee script te acessen
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("more than 1 buildmanager");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    
    private GameObject turretToBuild;
    
    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

    

    public GameObject GetTurretToBuild ()
    {
        return turretToBuild;
    }


}
