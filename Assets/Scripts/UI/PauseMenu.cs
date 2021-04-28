using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject controlsMenuUI;
    
    

    private void Start()
    {
        pauseMenuUI.SetActive(false);
        controlsMenuUI.SetActive(false);
        DontDestroyOnLoad(gameObject);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        if (GameObject.Find("EnemySpawner(Clone)"))
        {
            GameObject player = GameObject.Find("Player (Legs)");
            PlayerOilController playerOilController = player.GetComponent<PlayerOilController>();
            playerOilController.inDark = true;
        }
        pauseMenuUI.SetActive(false);
        controlsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        GameObject player = GameObject.Find("Player (Legs)");
        PlayerOilController playerOilController = player.GetComponent<PlayerOilController>();
       playerOilController.inDark = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        pauseMenuUI.SetActive(false);
        controlsMenuUI.SetActive(true);

    }

    public void BackPause()
    {
        controlsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
      
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
