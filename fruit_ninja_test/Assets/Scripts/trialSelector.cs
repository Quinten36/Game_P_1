using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trialSelector : MonoBehaviour
{

    //public But ton button;
    private Gamemanager gameManager;
    private int SettrialNumber;
    public int tijdelijkSetTrial;

    // Start is called before the first frame update
    void Start()
    {
        //button = GetComponent<Button>();
        gameManager = GameObject.Find("Trial").GetComponent<Gamemanager>();
        
        //button.onClick.AddListener(SetTrialNumber);
    }

    // Update is called once per frame
    void Update()
    {
        SettrialNumber = PlayerPrefs.GetInt("trial", 0);
        Debug.Log(SettrialNumber);
        
    }
    
    void SetNumberTrial(int trialNummer)
    {
        PlayerPrefs.SetInt("trialSet", SettrialNumber);
        //Debug.Log(button.gameObject.name + " was clicked");
        //gameManager.SetTrial(trialNumber);
    }
}
