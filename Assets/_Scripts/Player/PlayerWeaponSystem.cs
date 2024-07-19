using System;
using System.Collections;
using UnityEngine;
using System.Threading.Tasks;

public class PlayerWeaponSystem : MonoBehaviour
{
    public static Weapon ActiveWeapon;
    
    [Header("Settings")]
    [SerializeField] private PointerButton attackButton;
    
    private Weapon[] _weapons;

    
    #region UNITY METHODS
    private void Awake()
    {
        _weapons = GetComponentsInChildren<Weapon>(true);
    }

    private async void Start()
    {
        SwitchWeapon("Unarmed");

        attackButton.onPointerDown += () =>
        {
            _activeAttackingButton = true;
            _clickAttackingButton = true;
        };
        attackButton.onPointerUp += () => _activeAttackingButton = false;

        await Async_Attacking();
    }

    #endregion
    
    #region PUBLIC METHODS
    
    public void SwitchWeapon(string weaponName)
    {
        if(ActiveWeapon) ActiveWeapon.gameObject.SetActive(false);

        ActiveWeapon = Array.Find(_weapons, weapon => weapon.weaponName == weaponName);
        if (!ActiveWeapon)
        {
            Debug.LogError("No weapon was found!");
            return;
        }
        
        ActiveWeapon.gameObject.SetActive(true);
        //SwitchWeaponAnimator(ActiveWeapon.weaponType);
    }
    
    private bool _activeAttackingButton;
    private bool _clickAttackingButton;
    private bool _attacking;
    
    #endregion

    #region PRIVATE METHODS

    private async Task Async_Attacking()
    {
        while (true)
        {
            await Task.Run(() => _activeAttackingButton || _clickAttackingButton);
            await Task.Delay((int)(ActiveWeapon.delayBeforeAttack * 1000));
            while (_activeAttackingButton || _clickAttackingButton)
            {
                ActiveWeapon.Attack();

                await Task.Delay((int)(ActiveWeapon.delayAttack * 1000));

                _clickAttackingButton = false;
            }
        }
    }

    #endregion
}
