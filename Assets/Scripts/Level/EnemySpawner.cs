using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> EnemyPool;
    public GameObject[] SpawnLocations;
    public int difficultyPoints = 20, level = 0, maxEnemies = 6;

    void Start()
    {
        
        SpawnLocations = GameObject.FindGameObjectsWithTag("SpawnLocation");
        level = 0;
        maxEnemies = 6 + 3 * (level / 3);
        difficultyPoints = 20 + (5 * ((level - 1) % 3)) + (20 * ((level - 1) / 3));
    }

    void Update()
    {
        
    }

    private void SpawnRandomEnemies(int amount)
    {
        for (int i = 0; i < amount; i ++)
        {
            
        }
    }
}
