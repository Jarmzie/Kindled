using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInfo : MonoBehaviour
{
    public List<GameObject> roomEnemyPool;
    public GameObject spawnlocation, door, exit, entrance;

    //I don't have time to create the general Room Info class so this is not how anything will work

    public virtual void SetUpEverything()
    {
        GameObject temp;
        temp = Instantiate(spawnlocation, new Vector2(8, -0.5f), Quaternion.identity);
        temp.transform.localScale = new Vector3(9, 5, 1);
        temp = Instantiate(spawnlocation, new Vector2(10, -0.5f), Quaternion.identity);
        temp.transform.localScale = new Vector3(5, 13, 1);
        //entrance = Instantiate(door, new Vector3(-1.5f, 3.5f, -0.5f), Quaternion.identity); THESE ARE DUMB I HATE EVERYTHING IT'S LITERALLY AN INSTANCE STOP YELLING AT ME
        //exit = Instantiate(door, new Vector3(10.5f, 7.5f, -0.5f), Quaternion.identity);
    }
}
