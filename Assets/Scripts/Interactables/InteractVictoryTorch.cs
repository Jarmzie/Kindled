using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractVictoryTorch : Interactable
{
    [SerializeField]
    private GameObject dialoguePrefab, winTorch, myLight;

    private void Awake()
    {
        InteractMessage = "Turn Wheel - Press 'E'";
    }

    public override IEnumerator OnInteract()
    {
        GameObject.FindGameObjectWithTag("PlayerLegs").GetComponent<PlayerMovement>().CutsceneMe(false);
        winTorch.GetComponent<Animator>().SetTrigger("DevilComes");
        myLight.GetComponent<Animator>().SetTrigger("LetThereBeLight");
        yield return new WaitForSeconds(3.0f);
        GameObject temp = Instantiate(dialoguePrefab);
        temp.GetComponent<Dialogue>().RunDialogue("", new string[] {
            "You turned on what seems to be a generator.",
            "You also found a lantern hidden in the corner."
        }, gameObject, "EndGame");
        yield return null;
    }

    public void DialogueEnd(string CallbackID)
    {
        if (CallbackID == "EndGame")
        {
            GameObject.FindGameObjectWithTag("LevelLogic").GetComponent<LevelLogic>().StartRestartForFinish(GameObject.FindGameObjectWithTag("PlayerLegs"));
        }
    }
}
