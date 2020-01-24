using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control : MonoBehaviour
{

    public static float life = 3;
    public static float score = 0;

    //public GameObject scoreText;
    //public GameObject lifeText;
    public Text scoresText;
    public Text lifesText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            lifesText.text = "GAMEOVER";
            Waypoints.points[1] = null;
        } else
        {
            lifesText.text = "Lifes: " + life;
        }
        scoresText.text = "Score: "+score;
        //lifesText.text = "Lifes: " + life;
    }
}
