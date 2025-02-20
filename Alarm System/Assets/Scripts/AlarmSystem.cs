using UnityEngine;
using System.Collections.Generic;

public class AlarmSystem : MonoBehaviour
{
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

    private void DetectionHandling()
    {
        if (_volumeChanger.IsAlarmActive)
        {
            _volumeChanger.DecreaseVolume();
        }
        else
        {
            _volumeChanger.IncreaseVolume();
        }
    }
}