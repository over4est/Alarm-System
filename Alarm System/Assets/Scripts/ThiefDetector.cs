using System;
using UnityEngine;

public class ThiefDetector : MonoBehaviour
{
    public event Action ThiefDetected;
    public event Action ThiefGone;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Thief>(out _))
        {
            ThiefDetected?.Invoke();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<Thief>(out _))
        {
            ThiefGone?.Invoke();
        }
    }
}