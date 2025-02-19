using System;
using UnityEngine;

public class ThiefDetector : MonoBehaviour
{
    public event Action<Vector3, Vector3> ThiefDetected;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Thief>(out Thief thief))
        {
            ThiefDetected?.Invoke(transform.position, thief.MovementStep);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<Thief>(out Thief thief))
        {
            ThiefDetected?.Invoke(transform.position, thief.MovementStep);
        }
    }
}