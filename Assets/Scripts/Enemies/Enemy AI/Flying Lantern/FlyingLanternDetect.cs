using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingLanternDetect : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            this.transform.parent.GetComponent<FlyingLanternAI>().playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            this.transform.parent.GetComponent<FlyingLanternAI>().playerInRange = false;
        }
    }
}
