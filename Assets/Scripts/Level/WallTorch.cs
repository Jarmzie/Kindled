using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class WallTorch : MonoBehaviour
{
    Animator an;
    Light2D myLight;

    void Awake()
    {
        an = GetComponent<Animator>();
        myLight = GetComponent<Light2D>();
    }

    public void LetThereBeLight()
    {
        an.SetTrigger("LetThereBeLight");
        myLight.pointLightInnerRadius = 1;
        myLight.pointLightOuterRadius = 3;
    }

    public void ResetLight()
    {
        an.SetTrigger("Reset");
        myLight.pointLightInnerRadius = 0;
        myLight.pointLightOuterRadius = 0;
    }
}
