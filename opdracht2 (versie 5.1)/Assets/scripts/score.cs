using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{

    public Text scoreText;
    public int puntenAantal;
    private int Score;
    private int setSccore;

   

    // Start is called before the first frame update
    void Start()
    {
        //Score = 0;
        //PlayerPrefs.SetInt("Score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Delete))
        //{
        //    PlayerPrefs.SetInt("Score", 0);
        //}
    }

    private void OnTriggerExit(Collider other)
    {

        Debug.Log(Score);
        Score = beweeg.Score;
        Score += puntenAantal;
        beweeg.Score = Score;





        //Debug.Log(Score);
        //Score = PlayerPrefs.GetInt("Score", 0);
        //Score += puntenAantal;
        //PlayerPrefs.SetInt("Score", Score);
        //Score += puntenAantal;


        //setSccore = PlayerPrefs.GetInt("Score", 0);
        setSccore = beweeg.Score;
        scoreText.text = "Score: " + setSccore;
    }
   
}
