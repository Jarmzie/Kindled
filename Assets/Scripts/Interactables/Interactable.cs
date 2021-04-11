using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string InteractMessage = "Message.Default";
    private bool interactReset = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey("e") && interactReset)
        {
            StartCoroutine(OnInteract());
            interactReset = false;
        }
    }

    public virtual IEnumerator OnInteract()
    {
        print("Error: Default OnInteract() Method Invoked");
        yield return new WaitForSeconds(1);
        interactReset = true;
        yield return null;
    }
}
