using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public float fireDelayTime = 0.5f;
    private float nextFire;
    
    public void Fire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireDelayTime;
            Pooling.current.BulletShot();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }
}
