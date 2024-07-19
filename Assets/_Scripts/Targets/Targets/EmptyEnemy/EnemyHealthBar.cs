using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI hpTextStatus;
    
    private EmptyEnemy _emptyEnemy;
    private void Awake()
    {
        _emptyEnemy = GetComponent<EmptyEnemy>();

        healthSlider.maxValue = _emptyEnemy.maxHp;
        healthSlider.value = _emptyEnemy.maxHp;
        
        hpTextStatus.text = $"Hp: {_emptyEnemy.maxHp}/{_emptyEnemy.maxHp}";
    }

    private void OnEnable()
    {
        _emptyEnemy.onHpChange += UpdateStatusHp;
    }

    private void OnDisable()
    {
        _emptyEnemy.onHpChange -= UpdateStatusHp;
    }

    private void UpdateStatusHp(int newHp)
    {
        healthSlider.value = newHp;
        hpTextStatus.text = $"Hp: {newHp}/{_emptyEnemy.maxHp}";
    }
}
