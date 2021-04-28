using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrontBack : MonoBehaviour
{
    float[] heightDiffFront, heightDiffBack;
    Transform PlayerLoc;
    float PlayerHeight;

    private void Awake()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("PlayerLegs");
        PlayerLoc = temp.GetComponent<Transform>();
        PlayerHeight = temp.GetComponent<SpriteRenderer>().size.y / 2;
    }

    private void Update()
    {
        SortedList<float, GameObject> enemiesInFront = new SortedList<float, GameObject>(), enemiesInBack = new SortedList<float, GameObject>();
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("EnemyLayer"))
        {
            Enemy tempEnemy = enemy.GetComponent<Enemy>();
            if (tempEnemy.heightDiffFromPlayer > 0)
            {
                enemiesInBack.Add(tempEnemy.heightDiffFromPlayer, enemy);
            } else
            {
                enemiesInFront.Add(tempEnemy.heightDiffFromPlayer, enemy);
            }
        }
        for (int i = 0; i < enemiesInBack.Count; i++)
        {
            enemiesInBack.Values[i].GetComponent<SpriteRenderer>().sortingLayerName = "EnemyInBack";
            enemiesInBack.Values[i].GetComponent<SpriteRenderer>().sortingOrder = i;
        }
        for (int i = 0; i < enemiesInFront.Count; i++)
        {
            enemiesInFront.Values[i].GetComponent<SpriteRenderer>().sortingLayerName = "EnemyInFront";
            enemiesInFront.Values[i].GetComponent<SpriteRenderer>().sortingOrder = i;
        }
    }
}
