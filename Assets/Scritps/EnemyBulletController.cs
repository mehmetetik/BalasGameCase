using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class EnemyBulletController : MonoBehaviour
{
    public GameObject target;
    public float speed = 5;
    public float damage = 1;
    
    void Start()
    {
        target = GameObject.Find("AirPlane");
    }

    private void OnEnable()
    {
        Invoke("HideBullet", 2);
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
    

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        // Düşman mermisi ile uçak arasındaki çarpışmayı algılıyor ve uçağın canını azaltıyoruz
        if (other.gameObject.tag == "AirPlane")
        {
            AirPlaneManager.current.TakeDamage(damage);
            Debug.Log("bullet trigger airplane");
        }
    }
}
