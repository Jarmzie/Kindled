using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

/*public class PlayerAimWeapon : MonoBehaviour
{
    
    public event EventHandler<OnShootEventArgs> OnShoot;

    public class OnShootEventArgs : EventArgs
    {
        public Vector3 lanternEndPointPosition;
        public Vector3 shootPosition;
    }


    private Transform aimTransform;
    public Transform aimLanternEndPointTransform;

    public GameObject bulletPrefab;
  

    public float bulletForce = 10f;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        aimLanternEndPointTransform = aimTransform.Find("LanternEndPointPosition");
    }

    private void Update()
    {
        HandleAiming();
       // HandleShooting();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
       
    }

  

    void Shoot()
    {
       GameObject bullet = Instantiate(bulletPrefab, aimLanternEndPointTransform.position, aimLanternEndPointTransform.rotation);
       Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(aimLanternEndPointTransform.up * bulletForce, ForceMode2D.Impulse);
    }

    private void HandleAiming()
    {
        Vector3 MousePosition = UtilsClass.GetMouseWorldPosition();


        Vector3 aimDirection = (MousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        //makes the spirte flip so it is never upsidedown (cant use with current shooting set up) will look into it
        *//*
        Vector3 aimLocalScale = Vector3.one;
        if(angle > 90 || angle < -90)
        {
            aimLocalScale.y = -1f;      

        }
        else
        {
            aimLocalScale.y = +1f;
            
        }
        aimTransform.localScale = aimLocalScale;
         *//*
    }

    //for adding affects later if wanted
    private void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 MousePosition = UtilsClass.GetMouseWorldPosition();

            //future shooting animation if we want one
            OnShoot?.Invoke(this, new OnShootEventArgs
            {
                lanternEndPointPosition = aimLanternEndPointTransform.position,
                shootPosition = MousePosition,

            });

        }
    }
}*/
