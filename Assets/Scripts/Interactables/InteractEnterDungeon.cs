using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractEnterDungeon : Interactable
{
    public GameObject LL;

    [SerializeField]
    private GameObject dialoguePrefab;

    private void Awake()
    {
        InteractMessage = "Enter Dungeon - Press 'E'";
    }

    public override IEnumerator OnInteract()
    {
        if (GameObject.FindGameObjectsWithTag("HubStateManager").Length > 0 && GameObject.FindGameObjectWithTag("HubStateManager").GetComponent<HubStateManager>().myTutState == HubStateManager.TutorialState.FirstLoad)
        {
            GameObject tempDialogue = Instantiate(dialoguePrefab, Vector3.zero, Quaternion.identity);
            tempDialogue.GetComponent<Dialogue>().RunDialogue("", new string[] {
                    "Maybe I should talk to the locals before entering random doors."
                });
            yield break;
        }
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
