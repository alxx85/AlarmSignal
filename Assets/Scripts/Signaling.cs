using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    private AudioSource _alarm;
    private SpriteRenderer _renderer;
    private bool _isActivated;
    private float _volumeMax = 1f;
    private float _volumeMin = 0f;
    private float _volumeStep = 0.1f;
    private float _delayStepVolume = 0.5f;

    private void Start()
    {
        _alarm = GetComponent<AudioSource>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void ThiefUsingDoor()
    {
        _isActivated = !_isActivated;

        if (_isActivated)
        {
            _alarm.Play();
            StopCoroutine(StopAlarm());
            StartCoroutine(StartAlarm());
            StartCoroutine(ColorSignaling());
        }
        else
        {
            StopCoroutine(StartAlarm());
            StopCoroutine(ColorSignaling());
            StartCoroutine(StopAlarm());
        }
    }

    private IEnumerator StartAlarm()
    {
        while (_alarm.volume < _volumeMax)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, _volumeMax, _volumeStep);
            yield return new WaitForSeconds(_delayStepVolume);
        }
    }

    private IEnumerator StopAlarm()
    {
        while (_alarm.volume > _volumeMin)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, _volumeMin, _volumeStep);
            yield return new WaitForSeconds(_delayStepVolume);
        }
        _alarm.Stop();
    }

    private IEnumerator ColorSignaling()
    {
        while (_isActivated)
        {
            _renderer.color = Color.red;
            yield return new WaitForSeconds(_delayStepVolume);
            _renderer.color = Color.white;
            yield return new WaitForSeconds(_delayStepVolume);
        }
    }
}
