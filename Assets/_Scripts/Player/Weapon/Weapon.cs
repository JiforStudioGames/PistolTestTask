using System;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Weapon : MonoBehaviour
{
    [Header("Base Settings")] 
    public string weaponName;
    public WeaponType weaponType;
    //public float distanceFromTarget = 1f;
    
    [Space] 
    public float delayBeforeAttack = 0.2f;
    public float delayAttack = 1f;
    
    public Action onAttack;
    
    #region UNITY METHODS

    public virtual void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    /*private void Update()
    {
        if (PlayerTargetSystem.ActiveTarget != null)
        {
            Vector2 direction = PlayerTargetSystem.ActiveTarget.GetPosition() - firePoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }*/

    #endregion
    
    #region PUBLIC METHODS

    public virtual void Attack()
    {
        onAttack?.Invoke();
    }
    
    #endregion
}
