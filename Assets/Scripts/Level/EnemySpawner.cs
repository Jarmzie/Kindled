using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> EnemyPool;
    public LevelLogic CurrentLevelLogic;
    public GameObject[] SpawnLocations;
    public GameObject spawnBubble;
    public int difficultyPoints, level, maxEnemies, decisionChecks = 0;
    private float spawnRate = 0;
    private int numOfEnemies = 0;

    //These are all variables so that we can tweak them
    public int perLevelDPIncrease = 5, upgradeFrequency = 3, upgradeIncrease = 20, startingDP = 10, startingMaxEnemies = 6, maxEnemyIncrease = 3;

    public void GeneralSetUp(int level_, LevelLogic CurrentLevelLogic_)
    {
        level = level_;
        CurrentLevelLogic = CurrentLevelLogic_;
        spawnRate = 8 + (-1 * ((0.58333333f * level) - 1));
        SpawnLocations = GameObject.FindGameObjectsWithTag("SpawnLocation");
        maxEnemies = startingMaxEnemies + maxEnemyIncrease * ((level - 1) / upgradeFrequency);
        difficultyPoints = 0;// startingDP + (perLevelDPIncrease * ((level - 1) % upgradeFrequency)) + (upgradeIncrease * ((level - 1) / upgradeFrequency));
        InvokeRepeating("DecideSpawning", 3.0f, spawnRate);
    }

    private void Update()
    {
        numOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (difficultyPoints <= 0 && numOfEnemies <= 0)
        {
            CancelInvoke();
            CurrentLevelLogic.RoomFinished();
            Destroy(this.gameObject);
            //GameObject.Find("Level Logic").GetComponent<LevelLogic>().ri.exit.GetComponent<Door>().Open(); //Reaching through the computer screen myself to get to this door would probably be more efficient than this lol
        }
    }

    private void DecideSpawning()
    {
        if (difficultyPoints > 0)
        {
            StartCoroutine(SpawnRandomEnemies(2));
        }
    }

    private IEnumerator SpawnRandomEnemies(int amount)
    {
        for (int i = 0; i < amount; i ++)
        {
            GameObject enemyToSpawn = EnemyPool[Random.Range(0, EnemyPool.Count)];
            SpawnLocation SL = SpawnLocations[Random.Range(0, SpawnLocations.Length)].GetComponent<SpawnLocation>();
            Vector3 spawnLocation = new Vector3(SL.pos.x + Random.Range(-1 * SL.width / 2, SL.width / 2), SL.pos.y + Random.Range(-1 * SL.height / 2, SL.height / 2), -1);
            Instantiate(spawnBubble, spawnLocation, Quaternion.identity);
            yield return new WaitForSeconds(1);
            GameObject tempEnemy = Instantiate(enemyToSpawn, spawnLocation, Quaternion.identity);
            difficultyPoints -= tempEnemy.GetComponent<Enemy>().cost;
        }
        yield return null;
    }
}
