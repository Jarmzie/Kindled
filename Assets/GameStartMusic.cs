using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Plays("TownHubMusic");
    }

    
}
