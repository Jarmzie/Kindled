using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Plays("MainMenuMusic");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("TownHub");
        FindObjectOfType<AudioManager>().Stop("MainMenuMusic");
    }
    
}
