using System;
using UnityEngine;

public class ThiefDetector : MonoBehaviour
{
    public event Action ThiefDetected;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Thief>(out _))
        {
            ThiefDetected?.Invoke();
        }
    }
}