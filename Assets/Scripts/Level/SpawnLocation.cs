using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocation : MonoBehaviour
{
    public GameObject myQuad;
    public MeshCollider myRange;
    public Vector2 pos;
    public float width, height;

    private void Start()
    {
        myRange = myQuad.GetComponent<MeshCollider>();
        pos = myRange.bounds.center;
        width = myRange.bounds.max.x;
        height = myRange.bounds.max.y;
    }
}
