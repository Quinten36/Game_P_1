using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public List<GameObject> targets;
    public List<GameObject> trials;
    public int Level = 1;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI endText;
    public int coins;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    public Slider slider;
    public Button ActivateBTN;
    public TextMeshProUGUI spaceText;
    public bool isGameActive;
    private int score;
    private float spawnRate = 1.0f;
    public int level;
    public float levelUpScore = 150;
    public int multiplier = 1;
    public bool doubleScore;
    public TimeManager timeManager;
    private int SettrialNumber;
    private int playerLevel;
    private int countdown;
    private bool firstTime;
    private bool gameEnd;

    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
        firstTime = true;
      doubleScore = false;
      gameEnd = false;
      // PlayerPrefs.SetInt("trial", 0);
      // PlayerPrefs.SetInt("trialSet", 0);

/*** timeManager.Slowmotion(); ***/
      SettrialNumber = PlayerPrefs.GetInt("trial", 0);
      Debug.Log("trial"+SettrialNumber);

        playerLevel = PlayerPrefs.GetInt("level");
        Debug.Log("level" + playerLevel);

      // GameObject Tijdelijke_trial_handeller;
			// Tijdelijke_trial_handeller = Instantiate(trials[SettrialNumber]) as GameObject;
      Instantiate(trials[SettrialNumber]);
    }

    // Update is called once per frame
    void Update()
    {
      SettrialNumber = PlayerPrefs.GetInt("trial", 0);
      Debug.Log("trial"+SettrialNumber);
      if (isGameActive && slider.value >= 100 && Input.GetKeyDown(KeyCode.Space)) {
        //if (slider.value >= 100) {
          //if (Input.GetKeyDown(KeyCode.Space)) {
            ActivateBTN.onClick.Invoke();
          //}
        //}
      }
      // Debug.Log(countdown);
      if (countdown != 0)
      {
        countdownText.gameObject.SetActive(true);
        countdownText.text = countdown + " sec left";
      } else {
        countdownText.gameObject.SetActive(false);
      }
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            // timeManager.Slowmotion();
        }

    }

    public void UpdateScore(int scoreToAdd)
    {
       if (scoreToAdd < 0) {
         score += scoreToAdd;
         coins += 1;
        } else {
         score += scoreToAdd * multiplier;
         coins += 15;
        }
        if (firstTime == true)
        {
            coins = 0;
            firstTime = false;
        }
        coinText.text = "Coins: " + coins;
        PlayerPrefs.SetInt("coins", coins);
      scoreText.text = "Score: " + score;
        //Debug.Log(Level);
        //Debug.Log(spawnRate);
        PlayerPrefs.SetInt("level", 1);
        if (Level == 1/* && Level < 2*/ && score > 300)
        {
          PlayerPrefs.SetInt("level", 2);
          SceneManager.LoadScene("level2");
        } else if (Level == 2 && spawnRate == 0.5 && score > 250)
        {
          PlayerPrefs.SetInt("level", 3);
          SceneManager.LoadScene("level3");
        }
        else if (Level == 3 && spawnRate < 0.5 && score > 2)
        {
          Debug.Log("gelukt");
          PlayerPrefs.SetInt("coin", 999999999);
          gameEnd = true;
          endText.gameObject.SetActive(true);
          //een tekst in beeld laten komen dat hij op max level is
        }      

        //slider/double score 
        slider.value += scoreToAdd; 
        if (slider.value >= 100) {
          ActivateBTN.gameObject.SetActive(true);
          spaceText.gameObject.SetActive(true);
          //slider.value = 100;
        } else if (slider.value < 100) {
          ActivateBTN.gameObject.SetActive(false);
          spaceText.gameObject.SetActive(false);
          //slider.value = 100;
        }

    }

    public void GameOver()
    {
      if (gameEnd) {

      } else {
        PlayerPrefs.SetInt("coins", coins);
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
      }
    }

    public void RestartGame()
    {
      //QQ PlayerPrefs.SetInt("Level", level);
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
      //check in maken zodat je alleen met level 1 east. level 2 medium ect
        isGameActive = true;
        endText.gameObject.SetActive(false);
        score = 0;
        spawnRate /= difficulty;
        level = difficulty;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        titleScreen.gameObject.SetActive(false);
        coins = PlayerPrefs.GetInt("coins");

        //Debug.Log(difficulty);
    }

   public void ActivatePowerup() {
     slider.value = 0;
     ActivateBTN.gameObject.SetActive(false);
     spaceText.gameObject.SetActive(false);
     StartCoroutine("DoubleScore");
   }

   public IEnumerator DoubleScore() {
     multiplier = 2;
     //Debug.Log("Activate");
     slider.gameObject.SetActive(false);
     countdown = 5;
     yield return new WaitForSeconds(1);
     countdown = 4;
     yield return new WaitForSeconds(1);
     countdown = 3;
     yield return new WaitForSeconds(1);
     countdown = 2;
     yield return new WaitForSeconds(1);
     countdown = 1;
     yield return new WaitForSeconds(1);
     countdown = 0;
     multiplier = 1;
     slider.value = 0;
     yield return new WaitForSeconds(5);
     slider.value = 0;
     yield return new WaitForSeconds(5);
     slider.value = 0;
     slider.gameObject.SetActive(true);
   }

    public void BackLevel() 
    {
        playerLevel = PlayerPrefs.GetInt("level", 0);
        Debug.Log(playerLevel);
        SceneManager.LoadScene("level" + playerLevel);
        //dit moet de variabele van player frebs zijn
    }

    public void toOptions() 
    {
        SceneManager.LoadScene("options");
        //dit moet de variabele van player frebs zijn
    }

    public void resetCoins() 
    {
        coins = 0;
        PlayerPrefs.SetInt("coins", coins);
    }
}

//target = GameObject.Find("Target").GetComponent<Target>();

//if (score >= 100) {
//  //if (level <= 3) {
//    level++;
//    levelUpScore += levelUpScore;
//  //}
//}
//Debug.Log(level);

//Debug.Log(doubleScore);

   
  //  void SetNumberTrial()
  //  {
  //    PlayerPrefs.SetInt("trialSet", SettrialNumber);
  //  }