using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public static HealthBar current;

    private float currentHealth = 0;
    private float targetHealth = 0;

    private Camera _cam;
    void Start()
    {
        current = this;
        _cam = Camera.main;
    }

    public void SetHealth(float health)
    {
        targetHealth = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetMaxHealth(float health)
    {
        currentHealth = health;
        targetHealth = health;
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }

    public void LateUpdate()
    {
        // SliderBar'da, can azalma sırasında yumuşak bi şekilde geçiş yapmasını sağlamak için
        currentHealth = Mathf.MoveTowards(currentHealth, targetHealth, 0.5f);
        slider.value = currentHealth;
    }
}
