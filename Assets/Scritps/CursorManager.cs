using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

    public Transform target;
    public SpriteRenderer cursor;

    private void Start()
    {
        cursor = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Uçak objesini sadece x ve z düzleminde takip etmek için.
        transform.position = new Vector3(target.transform.position.x, transform.position.y,
            target.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            cursor.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            cursor.color = Color.white;
        }
    }
}
