using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Rock : Target
{
    [SerializeField] private ParticleSystem onDestroyEffect;
    
    public override void TakeDamage()
    {
        onDestroyEffect.transform.SetParent(transform.parent);
        onDestroyEffect.Play();
        Destroy(gameObject);
    }
}
