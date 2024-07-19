using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockFPSGame : MonoBehaviour
{
    public int countFPS;
    void Awake()
    {
        Application.targetFrameRate = countFPS;
    }
}
