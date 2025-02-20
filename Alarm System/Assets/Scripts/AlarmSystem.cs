using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private ThiefDetector _thiefDetector;
    [SerializeField] private VolumeChanger _volumeChanger;

    private void OnEnable()
    {
        _thiefDetector.ThiefDetected += _volumeChanger.IncreaseVolume;
        _thiefDetector.ThiefGone += _volumeChanger.DecreaseVolume;
    }

    private void OnDisable()
    {
        _thiefDetector.ThiefDetected -= _volumeChanger.IncreaseVolume;
        _thiefDetector.ThiefGone -= _volumeChanger.DecreaseVolume;
    }
}