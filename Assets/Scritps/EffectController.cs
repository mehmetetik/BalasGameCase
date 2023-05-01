using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    public static EffectController current;

    public GameObject explosion;

    void Start()
    {
        current = this;

    }

    private void OnEnable()
    {
        Invoke("HideEffect", 1);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    public void HideEffect()
    {
        gameObject.SetActive(false);
        transform.position = Pooling.current.desPos.transform.position;
    }
}
