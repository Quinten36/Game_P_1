using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenuUI;

    [SerializeField] public bool isPaused;

    private Gamemanager gameManager;
    private int SettrialNumber;


    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<Gamemanager>();
        SettrialNumber = PlayerPrefs.GetInt("trial", 0);
        isPaused = false;
        //objectWithScript.GetComponent<mouse_follow2>();
    }

    private void Update()
    {
        if (gameManager.isGameActive)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused;
            }

            if (isPaused)
            {
                ActiveteMenu();
            }
            else
            {
                DeactivateMenu();
            } 
        }
    }

    void ActiveteMenu() 
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseMenuUI.SetActive(true);
        if (CompareTag("line")) {
            Time.timeScale = 1;
            gameManager.trials[SettrialNumber].SetActive(false);
        }
        //gameManager.trials.SetActive(false);
    }

    public void DeactivateMenu() 
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }
}
