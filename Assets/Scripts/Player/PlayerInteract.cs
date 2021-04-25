using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    public Text DisplayText;
    public bool contWriteText = false;

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Dialogue").Length < 1)
        {
            if (Input.GetKeyDown("e"))
            {
                if (Physics2D.OverlapCircle(transform.position + new Vector3(0, -0.25f, 0), 0.5f, 1 << 22))
                {
                    Interactable foundInteractable = Physics2D.OverlapCircleAll(transform.position + new Vector3(0, -0.25f, 0), 0.5f, 1 << 22)[0].gameObject.GetComponent<Interactable>();
                    StartCoroutine(foundInteractable.OnInteract());
                }
                else
                {
                    print("No interact");
                }
            }
        } else
        {
            contWriteText = false;
            DisplayText.text = "";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("UpgradeInteract") || collision.CompareTag("EnterDungeonInteract") || collision.CompareTag("ShopInteract"))
        {
            contWriteText = true;
            StartCoroutine(WriteText(collision.GetComponent<Interactable>().InteractMessage));
        }
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
