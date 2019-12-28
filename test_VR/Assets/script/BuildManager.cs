using System.Collections;
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
    public GameObject antotherTurretPrefab;
    
    private GameObject turretToBuild;

    

    public GameObject GetTurretToBuild ()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild (GameObject turret)
    {
        turretToBuild = turret;
    }

}
