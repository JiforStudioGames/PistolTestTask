using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITarget
{
    public bool TargetIgnore { get; set; }
    public void TakeDamage()
    {
        Debug.Log("TakeDamage");
    }

    public Vector3 GetPosition();
}
