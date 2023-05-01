using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class MoneyContoller : MonoBehaviour
{
    public float distance = 20;
    public float airPlaneDes;
    public float moneySpeed = 100;
    public GameObject target;
    void Start()
    {
        target = GameObject.Find("AirPlane");
        var rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * Random.Range(5f, 15f));
        rb.AddForce(Vector3.right * Random.Range(0, 5f));
        rb.AddForce(Vector3.left * Random.Range(0, 5f));
    }

    void Update()
    {
        airPlaneDes = Vector3.Distance(transform.position, target.transform.position);
        

        if (airPlaneDes < distance)
        {
            // para uçağa doğru uçacak.
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moneySpeed * Time.deltaTime);
            Invoke("HideMoney", 3);
        }
    }
    
    private void OnEnable()
    {
        //Invoke("HideMoney", 2);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    public void HideMoney()
    {
        gameObject.SetActive(false);
        //gameObject.transform.GetChild(0).transform.position = Vector3.zero;
        transform.position = Pooling.current.desPos.transform.position;
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "AirPlane")
        {
            AirPlaneManager.current.moneyCount += 5;
        }
    }
}
