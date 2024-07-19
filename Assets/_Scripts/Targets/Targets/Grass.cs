using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Grass : Target
{
    [SerializeField] private ParticleSystem onDamageEffect;

    public bool Ignore { get; set; }

    public override void TakeDamage()
    {
        onDamageEffect.Play();
    }
}
