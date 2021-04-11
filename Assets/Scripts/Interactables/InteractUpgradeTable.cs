using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractUpgradeTable : Interactable
{
    private void Awake()
    {
        InteractMessage = "Upgrade Table 'E'";
    }

    public override IEnumerator OnInteract()
    {
        //Don't do anything you fool bitch dumb
        yield return null;
    }
}
