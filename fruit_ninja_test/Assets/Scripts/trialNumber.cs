using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
    private int coinAmount;
    public TextMeshProUGUI coinText;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<Gamemanager>();

        //if ()
        //PlayerPrefs.SetInt("trial", 0);
        PlayerPrefs.SetInt("trialSet", 0);
        coinAmount = PlayerPrefs.GetInt("coins", 0);
    

        button.onClick.AddListener(TrialNummer);



        //coinAmount = gameManager.coins;
    }
        

    // Update is called once per frame
    void Update()
    {
        Debug.Log(coinAmount);
        gameManager.coinText.text = "Coins: " + coinAmount;
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
        switch (trialNummer)
        {
            case 0:
                if (coinAmount >= 100)
                {
                    PlayerPrefs.SetInt("trial", trialNummer);
                    coinAmount -= 100;
                    PlayerPrefs.SetInt("coins", coinAmount);
                    // een void activeren die er coins vanaf haald
                    print("Je heb skin 1 gekocht");
                }
                break;
            case 1:
                if (coinAmount >= 100)
                {
                    PlayerPrefs.SetInt("trial", trialNummer);
                    coinAmount -= 100;
                    PlayerPrefs.SetInt("coins", coinAmount);
                    // een void activeren die er coins vanaf haald
                    print("Je heb skin 2 gekocht");
                }
                break;
            case 2:
                if (coinAmount >= 250)
                {
                    PlayerPrefs.SetInt("trial", trialNummer);
                    coinAmount -= 250;
                    PlayerPrefs.SetInt("coins", coinAmount);
                    // een void activeren die er coins vanaf haald
                    print("Je heb skin 3 gekocht");
                }
                break;
            case 3:
                if (coinAmount >= 100)
                {
                    PlayerPrefs.SetInt("trial", trialNummer);
                    coinAmount -= 100;
                    PlayerPrefs.SetInt("coins", coinAmount);
                    // een void activeren die er coins vanaf haald
                    print("Je heb skin 4 gekocht");
                }
                break;
            case 4:
                if (coinAmount >= 200)
                {
                    PlayerPrefs.SetInt("trial", trialNummer);
                    coinAmount -= 200;
                    PlayerPrefs.SetInt("coins", coinAmount);
                    // een void activeren die er coins vanaf haald
                    print("Je heb skin 5 gekocht");
                }
                break;
            default:
                break;
        }

        SceneManager.LoadScene("options");
        //Debug.Log(button.gameObject.name + " was clicked");
        //trial.SetNumberTrial(trialNummer);
    }
}
