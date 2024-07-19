using System;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerTargetSystem : MonoBehaviour
{
    [CanBeNull] public static ITarget ActiveTarget;
    
    private CircleCollider2D _circleCollider;
    private void Start()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out ITarget target))
        {
            if(target.TargetIgnore) return;
            ActiveTarget = target;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out ITarget target))
        {
            if (target == ActiveTarget) ActiveTarget = null;
        }
    }

    private void FixedUpdate()
    {
        if(ActiveTarget == null) FindNewTarget();
    }

    private void FindNewTarget()
    {
        Collider2D[] results = Physics2D.OverlapCircleAll(transform.position, _circleCollider.radius);
        foreach (Collider2D collider in results)
        {
            if (collider.gameObject.TryGetComponent(out ITarget target))
            {
                if(target.TargetIgnore) return;
                ActiveTarget = target;
            }
        }
    }
}
