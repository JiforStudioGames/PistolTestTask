using UnityEngine;

public abstract class Target : MonoBehaviour, ITarget
{
    [SerializeField] private bool targetIgnore;

    public bool TargetIgnore
    {
        get => targetIgnore;
        set => targetIgnore = value;
    }

    public abstract void TakeDamage();

    public Vector3 GetPosition() => transform.position;
}
