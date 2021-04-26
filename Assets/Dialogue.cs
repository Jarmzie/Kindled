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
    GameObject creator;
    string endCallback = "", dName = "";
    float textTime = 0.03f;

    public void RunDialogue(string name_, string[] ListOStrings)
    {
        dName = name_;
        DialogueString = ListOStrings;
        myText = transform.Find("DialogueText").GetComponent<Text>();
        if (GameObject.FindGameObjectsWithTag("PlayerLegs").Length > 1)
        {
            GameObject.FindGameObjectWithTag("PlayerLegs").GetComponent<PlayerMovement>().enabled = false;
        }
        if (DialogueString.Length > 0)
        {
            lastRoutine = StartCoroutine(WriteText(DialogueString[myPlace]));
        } else
        {
            Destroy(gameObject);
        }
    }

    public void RunDialogue(string name_, string[] ListOStrings, GameObject creator_, string endCallback_)
    {
        dName = name_;
        creator = creator_;
        endCallback = endCallback_;
        DialogueString = ListOStrings;
        myText = transform.Find("DialogueText").GetComponent<Text>();
        if (GameObject.FindGameObjectsWithTag("PlayerLegs").Length > 1)
        {
            GameObject.FindGameObjectWithTag("PlayerLegs").GetComponent<PlayerMovement>().enabled = false;
        }
        if (DialogueString.Length > 0)
        {
            lastRoutine = StartCoroutine(WriteText(DialogueString[myPlace]));
        }
        else
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
                if (creator != null)
                {
                    creator.SendMessage("DialogueEnd", endCallback);
                }
                Destroy(gameObject);
                return;
            }
            if (writing)
            {
                StopCoroutine(lastRoutine);
            }
            myPlace++;
            if (creator != null && DialogueString[myPlace].Substring(0, 1) == "\\")
            {
                //creator.SendMessage("DialogueCallback", myPlace); //Probably won't use but just in case, also probably don't use myPlace as callback ID
            } else
            {
                lastRoutine = StartCoroutine(WriteText(DialogueString[myPlace]));
            }
            
        }
    }

    private IEnumerator WriteText(string message)
    {
        writing = true;
        for (int i = 0; i < message.Length + 1; i++)
        {
            myText.text = dName + message.Substring(0, i);
            yield return new WaitForSeconds(textTime);
        }
        writing = false;
        yield return null;
    }
}
