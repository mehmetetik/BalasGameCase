using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class AirPlaneManager : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 100;

    public HealthBar healthBar;

    public int moneyCount = 0;
    public Text moneyText;

    public static AirPlaneManager current;

    void Start()
    {
        current = this;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void Update()
    {
        moneyText.text = moneyCount.ToString();
    }
}
