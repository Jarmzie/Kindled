using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobDetect : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("PlayerLegs"))
        {
            this.transform.parent.GetComponent<BlobScript>().playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("PlayerLegs"))
        {
            this.transform.parent.GetComponent<BlobScript>().playerInRange = false;
        }
    }


}
