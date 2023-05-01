using System;
using UnityEngine;

public class BaseHealthManager : MonoBehaviour
{
    public bool isHere;
    private AirPlaneManager _airPlaneManager;

    private void Update()
    {
        if (isHere)
        {
            if (_airPlaneManager.currentHealth < _airPlaneManager.maxHealth)
            {
                _airPlaneManager.currentHealth += 1 * (Time.deltaTime*5);
                _airPlaneManager.healthBar.SetHealth(_airPlaneManager.currentHealth);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AirPlane"))
        {
            _airPlaneManager = other.GetComponent<AirPlaneManager>();
            isHere = true; 
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("AirPlane"))
        {
            _airPlaneManager = null;
            isHere = false;
        }
    }
}
