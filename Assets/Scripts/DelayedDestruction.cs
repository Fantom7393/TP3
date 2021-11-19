using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDestruction : MonoBehaviour
{
    public float destructionDelay = 5f;
    void Start()
    {
        Destroy(gameObject, destructionDelay);
    }
}
