using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float destroyTime;
    [SerializeField] private ParticleSystem effectOnDestroy;
    private void Start()
    {
        Invoke(nameof(DestroyBullet), destroyTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.TryGetComponent(out ITarget target))
        {
            if(!target.TargetIgnore) target.TakeDamage();
        }
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        effectOnDestroy.Play();
        Destroy(gameObject);
    }
}
