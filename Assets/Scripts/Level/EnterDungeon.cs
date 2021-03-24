using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDungeon : MonoBehaviour
{
    public GameObject LL;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject temp = Instantiate(LL, Vector2.zero, Quaternion.identity);
        temp.GetComponent<LevelLogic>().NewRoom();
    }
}
