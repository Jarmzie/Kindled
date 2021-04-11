using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    Text DisplayText;
    bool contWriteText = false;

    private void Update()
    {
        if (Input.GetKey("e"))
        {
            Interactable foundInteractable = Physics2D.OverlapCircleAll(transform.position + new Vector3(0, -0.25f, 0), 0.5f, 23)[0].transform.parent.GetComponent<Interactable>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        contWriteText = true;
        StartCoroutine(WriteText(collision.gameObject.GetComponent<Interactable>().InteractMessage));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        contWriteText = false;
        DisplayText.text = "";
    }

    private IEnumerator WriteText(string message)
    {
        for (int i = 0; i < message.Length + 1; i++)
        {
            if (!contWriteText)
            {
                DisplayText.text = "";
                yield break;
            }
            DisplayText.text = message.Substring(0,i);
            yield return new WaitForSeconds(0.05f);
        }
        contWriteText = false;
        yield return null;
    }
}
