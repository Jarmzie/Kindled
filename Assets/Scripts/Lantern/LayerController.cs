using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerController : MonoBehaviour
{
    public bool front = true;
    SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void CheckAndSet()
    {
        if (front)
        {
            sr.sortingLayerName = "FrontForLantern";
        } else
        {
            sr.sortingLayerName = "BackForLantern";
        }
    }
}
