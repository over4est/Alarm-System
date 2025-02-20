using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private ThiefDetector _thiefDetector;
    [SerializeField] private VolumeChanger _volumeChanger;

    private void OnEnable()
    {
        _thiefDetector.ThiefDetected += IncreaseVolume;
        _thiefDetector.ThiefGone += DecreaseVolume;
    }

    private void OnDisable()
    {
        _thiefDetector.ThiefDetected -= IncreaseVolume;
        _thiefDetector.ThiefGone -= DecreaseVolume;
    }

    private void IncreaseVolume()
    {
        _volumeChanger.IncreaseVolume();
    }

    private void DecreaseVolume()
    {
        _volumeChanger.DecreaseVolume();
    }
}