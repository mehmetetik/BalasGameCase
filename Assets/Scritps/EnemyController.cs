using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemyAttack;
    public float distance = 20;
    public Transform target;
    public bool isDead;

    public float timer;

    private Animator enemyAnim;


    void Start()
    {
        enemyAnim = GetComponent<Animator>();
    }

    void Update()
    {
        enemyAttack = Vector3.Distance(transform.position, target.position);
        
        // Düşman objesinin sadece Y ekseninde hedefe bakmasını sağlayan kod satırımız.
        Vector3 targetPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        transform.LookAt(targetPos);


        if (!isDead)
        {
            if(enemyAttack < distance)
            {
                enemyAnim.SetBool("isShot", true);
                enemyAnim.SetBool("idle", false);
                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                }
                else
                {
                    Pooling.current.EnemyBulletShot(gameObject.transform.GetChild(3));
                    timer = 1;
                }
            }
            else
            {
                enemyAnim.SetBool("isShot", false);
                enemyAnim.SetBool("idle", true);

            }
        }
        else
        {
            enemyAnim.SetBool("isShot", false);
            enemyAnim.SetBool("isDead", true);
            for (int i = 0; i < 3; i++)
            {
                Pooling.current.Money(gameObject.transform);
            }
            enabled = false;
        }
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "rocket")
        {
            isDead = true;
            enemyAnim.SetBool("isShot", false);
            enemyAnim.SetBool("isDead", true);
            Destroy(gameObject,4);
        }
    }
}
