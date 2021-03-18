using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator an;
    private Collider2D col;
    private Rigidbody2D rb;

    void Start()
    {
        an = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Close()
    {
        an.SetTrigger("Close");
    }

    public void Open()
    {
        an.SetTrigger("Open");
        Destroy(rb);
        Destroy(col);
    }
}
