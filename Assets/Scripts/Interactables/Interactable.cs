using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string InteractMessage = "Message.Default";

    public virtual IEnumerator OnInteract()
    {
        print("Error: Default OnInteract() Method Invoked");
        yield return null;
    }
}
