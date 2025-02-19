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

    public void IncreaseVolume()
    {
        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }

        if (_corutine != null)
        {
            StopCoroutine(_corutine);
        }

        _corutine = StartCoroutine(ChangeVolume(_delay, _changeValue, _maxVolume));
    }

    public void DecreaseVolume()
    {
        if (_corutine != null)
        {
            StopCoroutine(_corutine);
        }

        _corutine = StartCoroutine(ChangeVolume(_delay, _changeValue, _minVolume));
    }

    private IEnumerator ChangeVolume(float delay, float changeValue, float target)
    {
        var wait = new WaitForSeconds(delay);

        while (_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, changeValue);

            yield return wait;
        }
    }
}