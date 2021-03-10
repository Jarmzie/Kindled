using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> EnemyPool;
    public GameObject[] SpawnLocations;
    public int difficultyPoints = 20, level = 1, maxEnemies = 6, decisionChecks = 0;

    //These are all variables so that we can tweak them
    public int perLevelDPIncrease = 5, upgradeFrequency = 3, upgradeIncrease = 20, startingDP = 20, startingMaxEnemies = 6, maxEnemyIncrease = 3;

    void Start()
    {
        SpawnLocations = GameObject.FindGameObjectsWithTag("SpawnLocation");
        level = 1;
        maxEnemies = startingMaxEnemies + maxEnemyIncrease * (level / upgradeFrequency);
        difficultyPoints = startingDP + (perLevelDPIncrease * ((level - 1) % upgradeFrequency)) + (upgradeIncrease * ((level - 1) / upgradeFrequency));
        SpawnRandomEnemies(3);
        InvokeRepeating("DecideSpawning", 0.0f, 7.0f);
    }

    private void DecideSpawning()
    {
        if (difficultyPoints <= 0)
        {
            print("No more enemies");
            CancelInvoke();
        }
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= maxEnemies / 2 && difficultyPoints > 0)
        {
            SpawnRandomEnemies(GameObject.FindGameObjectsWithTag("Enemy").Length / 2);
        }
    }

    private void SpawnRandomEnemies(int amount)
    {
        print("Running SpawnRandomEnemies");
        for (int i = 0; i < amount; i ++)
        {
            GameObject enemyToSpawn = EnemyPool[Random.Range(0, EnemyPool.Count)];
            SpawnLocation SL = SpawnLocations[Random.Range(0, SpawnLocations.Length)].GetComponent<SpawnLocation>();
            Vector3 spawnLocation = new Vector3(SL.pos.x + Random.Range(-1 * SL.width / 2, SL.width / 2), SL.pos.y + Random.Range(-1 * SL.height / 2, SL.height / 2), -1);
            Instantiate(enemyToSpawn, spawnLocation, Quaternion.identity);
            difficultyPoints -= enemyToSpawn.GetComponent<Enemy>().cost;
        }
    }
}
