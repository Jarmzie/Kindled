using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    string[] DialogueString;
    Text myText;
    bool writing = false;
    int myPlace = 0;
    Coroutine lastRoutine;

    [SerializeField]
    GameObject DialoguePrefab;

    public void RunDialogue(string[] ListOStrings)
    {
        DialogueString = ListOStrings;
        myText = transform.Find("DialogueText").GetComponent<Text>();
        //stop player moving
        if (DialogueString.Length > 0)
        {
            lastRoutine = StartCoroutine(WriteText(DialogueString[myPlace]));
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("e"))
        {
            if (myPlace + 1 >= DialogueString.Length)
            {
                Destroy(gameObject);
                return;
            }
            if (writing)
            {
                StopCoroutine(lastRoutine);
            }
            myPlace++;
            lastRoutine = StartCoroutine(WriteText(DialogueString[myPlace]));
        }
    }

    private IEnumerator WriteText(string message)
    {
        writing = true;
        for (int i = 0; i < message.Length + 1; i++)
        {
            myText.text = message.Substring(0, i);
            yield return new WaitForSeconds(0.05f);
        }
        writing = false;
        yield return null;
    }
}
