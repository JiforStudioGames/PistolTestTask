using UnityEngine;

public class BulletShooting : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private Rigidbody2D bulletPrefab;
    
    [Header("Settings")] 
    [SerializeField] private float bulletForce = 20f;

    [SerializeField] private int bulletsCount;
    [SerializeField] private float minSpreadAngle;
    [SerializeField] private float maxSpreadAngle;
    
    private Weapon _weapon;
    
    #region UNITY METHODS
    private void Awake()
    {
        _weapon = GetComponent<Weapon>();
    }

    private void OnEnable()
    {
        _weapon.onAttack += Shoot;
    }

    private void OnDisable()
    {
        _weapon.onAttack -= Shoot;
    }

    #endregion
    
    private void Shoot()
    {
        for (int i = 0; i < bulletsCount; i++)
        {
            var bulletRb = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            float spreadAngle = Random.Range(minSpreadAngle, maxSpreadAngle);
            if (PlayerTargetSystem.ActiveTarget != null)
            {
                Vector2 direction = PlayerTargetSystem.ActiveTarget.GetPosition() - firePoint.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                
                firePoint.rotation = Quaternion.Euler(0, 0, angle - 90f + spreadAngle);
                bulletRb.transform.rotation = Quaternion.Euler(0, 0, angle - 90f + spreadAngle);
            }
            else
            {
                firePoint.rotation = PlayerMovement._facingRight ? Quaternion.Euler(0, 0, -90f + spreadAngle) : Quaternion.Euler(0, 0, 90f + spreadAngle);
                bulletRb.transform.rotation = firePoint.rotation;
            }
        
            bulletRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }
}
