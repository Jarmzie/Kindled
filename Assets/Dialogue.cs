﻿using System.Collections;
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
        GameObject.FindGameObjectWithTag("PlayerLegs").GetComponent<PlayerMovement>().CutsceneMe(false);
        if (DialogueString.Length > 0)
        {
            lastRoutine = StartCoroutine(WriteText(DialogueString[myPlace]));
        } else
        {
            GameObject.FindGameObjectWithTag("PlayerLegs").GetComponent<PlayerMovement>().CutsceneMe(true);
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
        GameObject.FindGameObjectWithTag("PlayerLegs").GetComponent<PlayerMovement>().CutsceneMe(false);
        if (DialogueString.Length > 0)
        {
            lastRoutine = StartCoroutine(WriteText(DialogueString[myPlace]));
        }
        else
        {
            GameObject.FindGameObjectWithTag("PlayerLegs").GetComponent<PlayerMovement>().CutsceneMe(true);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("e"))
        {
            if (!writing && myPlace + 1 >= DialogueString.Length)
            {
                GameObject.FindGameObjectWithTag("PlayerLegs").GetComponent<PlayerMovement>().CutsceneMe(true);
                if (creator != null)
                {
                    creator.SendMessage("DialogueEnd", endCallback);
                }
                Destroy(gameObject);
                return;
            }
            if (writing)
            {
                FindObjectOfType<AudioManager>().Stop("LogNoise");
                StopCoroutine(lastRoutine);
                myText.text = dName + DialogueString[myPlace];
                writing = false;
                return;
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
            FindObjectOfType<AudioManager>().Plays("LogNoise");
            yield return new WaitForSeconds(textTime);
        }
        writing = false;
        FindObjectOfType<AudioManager>().Stop("LogNoise");
        yield return null;
    }
}
