using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractEnterDungeon : Interactable
{
    public GameObject LL;

    private void Awake()
    {
        InteractMessage = "Enter Dungeon - Press 'E'";
    }

    public override IEnumerator OnInteract()
    {
        GameObject.FindGameObjectWithTag("PlayerLegs").transform.Find("InteractSelector").GetComponent<PlayerInteract>().contWriteText = false;
        GameObject.FindGameObjectWithTag("PlayerLegs").transform.Find("InteractSelector").GetComponent<PlayerInteract>().DisplayText.text = "";
        FindObjectOfType<AudioManager>().Stop("TownHubMusic");
        FindObjectOfType<AudioManager>().Plays("EnterDungeon");
        GameObject temp = Instantiate(LL, Vector2.zero, Quaternion.identity);
        temp.GetComponent<LevelLogic>().NewRoom();
        FindObjectOfType<AudioManager>().Plays("CaveMusic");
        yield return null;
    }
}
