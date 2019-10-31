using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class trialNumber : MonoBehaviour
{
    
    private Button button;
    private Gamemanager gameManager;
    public int trialNummer;
    private int DestroyTrial;
    private int playerLevel;
    public List<GameObject> trials;
    private int SettrialNumber;
    private int firstTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<Gamemanager>();

        //if ()
        //PlayerPrefs.SetInt("trial", 0);
        PlayerPrefs.SetInt("trialSet", 0);
    

        button.onClick.AddListener(TrialNummer);   

        
    }
        

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void TrialNummer()
    {
        SettrialNumber = PlayerPrefs.GetInt("trial", 0);
        DestroyTrial = PlayerPrefs.GetInt("trial", 0);
  //      Debug.Log(DestroyTrial);

  //      GameObject Tijdelijke_trial_handeller;
		//Tijdelijke_trial_handeller = Instantiate(trials[SettrialNumber]) as GameObject;
        ////Instantiate(trials[SettrialNumber]);

        
        
        //Destroy(Tijdelijke_trial_handeller);
        //Instantiate(trials[trialNummer]);
        PlayerPrefs.SetInt("trial", trialNummer);
        SceneManager.LoadScene("options");
        //Debug.Log(button.gameObject.name + " was clicked");
        //trial.SetNumberTrial(trialNummer);
    }
}
