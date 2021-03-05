using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject proj;
    public Camera whatever;
    public int wait = 300;
    void Update()
    {
        if (wait > 0)
        {
            wait--;
        }
        if (Input.GetMouseButtonDown(0) && wait == 0)
        {
            Instantiate(proj, whatever.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1)), Quaternion.identity);
            wait = 500;
        }
    }
}
