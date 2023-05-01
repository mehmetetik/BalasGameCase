using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketManager : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("HideBullet", 2.5f);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    public void HideBullet()
    {
        gameObject.SetActive(false);
        transform.position = Pooling.current.desPos.transform.position;

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Pooling.current.effectPos = collision.transform;
            Pooling.current.ShowExplosionEffect();
        }
    }
}
