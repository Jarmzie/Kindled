using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLogic : MonoBehaviour
{
    public GameObject enemySpawn;
    public GameObject[] currSpawnLocations;
    public Door exit, entrance;
    private GameObject levelTransition;
    public int currLevel = 0;

    void Start()
    {
        levelTransition = transform.Find("ExitTrigger").gameObject;
        DontDestroyOnLoad(this.gameObject);
        UpdateToNewLevel();
    }

    void UpdateToNewLevel()
    {
        currLevel++;
        entrance = GameObject.FindWithTag("Entrance").GetComponent<Door>();
        entrance.Close();
        exit = GameObject.FindWithTag("Exit").GetComponent<Door>();
        exit.Close();
        levelTransition.transform.position = exit.transform.position;
        EnemySpawner roomES = Instantiate(enemySpawn, Vector2.zero, Quaternion.identity).GetComponent<EnemySpawner>();
        roomES.level = currLevel;
        roomES.CurrentLevelLogic = this;
    }

    public void RoomFinished()
    {
        //Turn lights on here
        //Make player stop losing oil
        exit.GetComponent<Door>().Open();
    }
}
