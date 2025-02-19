using UnityEngine;
using System.Collections.Generic;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private Transform _protectedObject;
    [SerializeField] private List<ThiefDetector> _thiefDetectors;
    [SerializeField] private VolumeChanger _volumeChanger;

    private void OnEnable()
    {
        foreach (ThiefDetector thiefDetector in _thiefDetectors)
        {
            thiefDetector.ThiefDetected += DetectionHandling;
        }
    }

    private void OnDisable()
    {
        foreach (ThiefDetector thiefDetector in _thiefDetectors)
        {
            thiefDetector.ThiefDetected -= DetectionHandling;
        }
    }

    private void DetectionHandling(Vector3 detectorPosition, Vector3 thiefMovementStep)
    {
        Vector3 thiefNextPosition = detectorPosition + thiefMovementStep;
        float sqrDetectorDistanceToObject = (_protectedObject.position - detectorPosition).sqrMagnitude;
        float sqrThiefDistanceToObject = (_protectedObject.position - thiefNextPosition).sqrMagnitude;

        if (sqrThiefDistanceToObject <= sqrDetectorDistanceToObject)
        {
            _volumeChanger.IncreaseVolume();
        }

        if (sqrThiefDistanceToObject > sqrDetectorDistanceToObject)
        {
            _volumeChanger.DecreaseVolume();
        }
    }
}