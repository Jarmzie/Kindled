using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLogic : MonoBehaviour
{
    public RoomInfo ri;
    public GameObject enemyspawn;

    //All of this is temporary because this class's structure does not allow me to make more indepth systems at this moment

    void Start()
    {
        ri = GameObject.Find("Room Info").GetComponent<RoomInfo>();
        ri.SetUpEverything();
        GameObject roomES = Instantiate(enemyspawn, Vector2.zero, Quaternion.identity);
        roomES.GetComponent<EnemySpawner>().EnemyPool = ri.GetComponent<RoomInfo>().roomEnemyPool;
        ri.entrance.GetComponent<Door>().Close();
        ri.exit.GetComponent<Door>().Close();
    }
}
