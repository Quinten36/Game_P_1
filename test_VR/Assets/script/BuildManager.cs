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

 

    public GameObject buildEffect;
    public GameObject sellEffect;

    private turretBlooprint turretToBuild;
    private node selectedNode;

    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }


    public void SelectNode (node Node)
    {
        if (selectedNode == Node)
        {
            DeselectNode();
            return;
        }
        selectedNode = Node;
        turretToBuild = null;

        nodeUI.SetTarget(Node);
    }

    public void DeselectNode ()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

   public void SelectTurretToBuild (turretBlooprint turret)
    {
        turretToBuild = turret;

        DeselectNode();
    }

    public turretBlooprint GetTurretToBuild ()
    {
        return turretToBuild;
    }
   
}
