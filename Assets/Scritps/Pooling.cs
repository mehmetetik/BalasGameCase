using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    public static Pooling current;
    
    // Rocket
    public List<GameObject> bullets = new List<GameObject>();
    public Transform bulletPos;
    public Transform bulletListedObject;

    public GameObject bulletPrefab;
    
    
    
    // Money
    public List<GameObject> moneys = new List<GameObject>();
    public Transform moneyPos;
    public Transform moneyListedObject;

    public GameObject moneyPrefab;
    
    
    // Effect
    public List<GameObject> effects = new List<GameObject>();
    public Transform effectPos;
    public Transform effectListedObject;

    public GameObject effectPrefab;
    
    // Enemy Bullet
    public List<GameObject> enemyBullets = new List<GameObject>();
    public Transform enemyBulletPos;
    public Transform enemyBulletListedObject;

    public GameObject enemyBulletPrefab;


    public Transform desPos;


    void Start()
    {
        if (current == null)
        {
            current = this;
        }
        
        // for döngüsü ile mermileri başlangıçta 10 kez çağırıp,
        // setActive kapalı şekilde listemize ve hiyerarşideki yerine ekliyoruz.
        for (int bullet = 0; bullet < 10; bullet++)
        {
            GameObject bulletObjcet = (GameObject)Instantiate(bulletPrefab);
            bulletObjcet.SetActive(false);
            bullets.Add(bulletObjcet);
            bulletObjcet.transform.parent = bulletListedObject.transform;
        }

        // Effect
        for (int effect = 0; effect < 10; effect++)
        {
            GameObject effectObject = (GameObject)Instantiate(effectPrefab);
            effectObject.SetActive(false);
            effects.Add(effectObject);
            effectObject.transform.parent = effectListedObject.transform;
        }
        
        
        // Money
        for (int money = 0; money < 50; money++)
        {
            GameObject moneyObject = (GameObject)Instantiate(moneyPrefab);
            moneyObject.SetActive(false);
            moneys.Add(moneyObject);
            moneyObject.transform.parent = moneyListedObject.transform;
        }
        
        
        
        // Enemy Bullet
        for (int enemyBullet = 0; enemyBullet < 100; enemyBullet++)
        {
            GameObject enemyBulletObject = (GameObject)Instantiate(enemyBulletPrefab);
            enemyBulletObject.SetActive(false);
            enemyBullets.Add(enemyBulletObject);
            enemyBulletObject.transform.parent = enemyBulletListedObject.transform;
        }
    }
    
    public void BulletShot()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                bullets[i].transform.position = bulletPos.position;
                bullets[i].SetActive(true);
                break;
            }
        }
    }
    
    
    public void Money(Transform pos)
    {
        for (int i = 0; i < moneys.Count; i++)
        {
            if (!moneys[i].activeInHierarchy)
            {
                moneys[i].transform.position = pos.position;
                moneys[i].SetActive(true);
                break;
            }
        }
    }

    public void ShowExplosionEffect()
    {
        for (int i = 0; i < effects.Count; i++)
        {
            if (!effects[i].activeInHierarchy)
            {
                effects[i].transform.position = effectPos.position;
                effects[i].SetActive(true);
                break;
            }
        }
    }

    public void EnemyBulletShot(Transform pos)
    {
        for (int i = 0; i < enemyBullets.Count; i++)
        {
            if (!enemyBullets[i].activeInHierarchy)
            {
                enemyBullets[i].transform.position = pos.position;
                enemyBullets[i].SetActive(true);
                break;
            }
        }
    }
}
