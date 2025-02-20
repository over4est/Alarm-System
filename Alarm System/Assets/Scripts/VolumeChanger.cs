using System.Collections;
using UnityEngine;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _changeValue;
    [SerializeField] AudioSource _audioSource;

    private float _maxVolume = 1;
    private float _minVolume = 0;
    private Coroutine _corutine;

    public bool IsAlarmActive => _audioSource.isPlaying;

    public void IncreaseVolume()
    {
        if (IsAlarmActive == false)
        {
            _audioSource.Play();
        }

        RestartCorutine(_maxVolume);
    }

    public void DecreaseVolume()
    {
        RestartCorutine(_minVolume);
    }

    private IEnumerator ChangeVolume(float delay, float changeValue, float target)
    {
        var wait = new WaitForSeconds(delay);

        while (_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, changeValue);

            yield return wait;
        }

        if (_audioSource.volume == _minVolume)
        {
            _audioSource.Pause();
        }
    }

    private void RestartCorutine(float target)
    {
        if (_corutine != null)
        {
            StopCoroutine(_corutine);
        }

        _corutine = StartCoroutine(ChangeVolume(_delay, _changeValue, target));
    }
}