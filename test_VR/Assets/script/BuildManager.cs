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

 

    public GameObject buildEffect;
    
    private turretBlooprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn (node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Too poor");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5.0f);

        Debug.Log("Turret build! Money left: " + PlayerStats.Money);
    }

   public void SelectTurretToBuild (turretBlooprint turret)
    {
        turretToBuild = turret;
    }

   
}
