using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{

    private Button button;
    private Gamemanager gameManager;

    public int difficulty;
    private int level;
    private int firstTime = 0;
    // public int level1 = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (firstTime == 0)
        {
            PlayerPrefs.SetInt("level", 1);
            firstTime = 1;
        }
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<Gamemanager>();

        button.onClick.AddListener(SetDifficulty);
        level = gameManager.level;

    }

    // Update is called once per frame
    void Update()
    {
      //Debug.Log(level);
      //Debug.Log(PlayerPrefs.GetInt("Level"));
    }

    //
    // public void levelSelector() {
    //   if (difficulty == level1) {
    //     Debug.Log("t");
    //   }
    // }

    void SetDifficulty()
    {
        //Debug.Log(button.gameObject.name + " was clicked");
        gameManager.StartGame(difficulty);
        //if (level == 1) {
        //  gameManager.StartGame(1);
        //}
        //if (level == 2) {
        //  gameManager.StartGame(2);
        //}
        //if (level == 3) {
        //  gameManager.StartGame(3);
        //}
    }
}


// if (level == 1 && difficulty < 2) {
//   // difficulty = 1;
//   gameManager.StartGame(difficulty);
// }
// else if (level == 2 && difficulty < 3) {
//   gameManager.StartGame(difficulty);
// }
// else if (level == 3) {
//   gameManager.StartGame(difficulty);
// }
// else {
//   Debug.Log("niet hoog genoeg level");
// }
