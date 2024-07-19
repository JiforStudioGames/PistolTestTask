using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EmptyEnemy : Target
{
    public int maxHp = 3;
    
    [SerializeField] private ParticleSystem onDamageEffect;
    [SerializeField] private ParticleSystem onDestroyEffect;
    
    public Action<int> onHpChange;

    private int _hp;

    private void Awake()
    {
        _hp = maxHp;
    }

    public override void TakeDamage()
    {
        _hp--;
        onHpChange?.Invoke(_hp);
        onDamageEffect.Play();
        
        if(_hp == 0)
        {
            onDestroyEffect.transform.SetParent(transform.parent);
            onDestroyEffect.Play();
            Destroy(gameObject);
        }
    }
}
