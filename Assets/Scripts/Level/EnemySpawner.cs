using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> EnemyPool;
    public LevelLogic CurrentLevelLogic;
    public GameObject[] SpawnLocations;
    public int difficultyPoints = 10, level = 1, maxEnemies = 6, decisionChecks = 0;

    //These are all variables so that we can tweak them
    public int perLevelDPIncrease = 5, upgradeFrequency = 3, upgradeIncrease = 20, startingDP = 10, startingMaxEnemies = 6, maxEnemyIncrease = 3;

    void Awake()
    {
        SpawnLocations = GameObject.FindGameObjectsWithTag("SpawnLocation");
        level = 1;
        maxEnemies = startingMaxEnemies + maxEnemyIncrease * (level / upgradeFrequency);
        difficultyPoints = 10;// startingDP + (perLevelDPIncrease * ((level - 1) % upgradeFrequency)) + (upgradeIncrease * ((level - 1) / upgradeFrequency));
        InvokeRepeating("DecideSpawning", 3.0f, 7.0f);
    }

    private void DecideSpawning()
    {
        if (difficultyPoints <= 0 && GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            CancelInvoke();
            CurrentLevelLogic.RoomFinished();
            //GameObject.Find("Level Logic").GetComponent<LevelLogic>().ri.exit.GetComponent<Door>().Open(); //Reaching through the computer screen myself to get to this door would probably be more efficient than this lol
        }
        if (difficultyPoints > 0)
        {
            SpawnRandomEnemies(2);
        }
    }

    private void SpawnRandomEnemies(int amount)
    {
        for (int i = 0; i < amount; i ++)
        {
            GameObject enemyToSpawn = EnemyPool[Random.Range(0, EnemyPool.Count)];
            SpawnLocation SL = SpawnLocations[Random.Range(0, SpawnLocations.Length)].GetComponent<SpawnLocation>();
            Vector3 spawnLocation = new Vector3(SL.pos.x + Random.Range(-1 * SL.width / 2, SL.width / 2), SL.pos.y + Random.Range(-1 * SL.height / 2, SL.height / 2), -1);
            Instantiate(enemyToSpawn, spawnLocation, Quaternion.identity);
            difficultyPoints = difficultyPoints - enemyToSpawn.GetComponent<Enemy>().cost;
        }
    }
}
