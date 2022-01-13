using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(SpriteRenderer))]
public class Signaling : MonoBehaviour
{
    private AudioSource _alarm;
    private SpriteRenderer _renderer;
    private bool _isActivated;
    private float _volumeMax = 1f;
    private float _volumeMin = 0f;
    private float _volumeStep = 0.1f;
    private List<Coroutine> _startCoroutines = new List<Coroutine>();
    private WaitForSeconds _delay = new WaitForSeconds(0.5f);

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
            StopRunningCoroutine();
            _startCoroutines.Add(StartCoroutine(StartAlarm()));
            _startCoroutines.Add(StartCoroutine(ColorSignaling()));
        }
        else
        {
            StopRunningCoroutine();
            _startCoroutines.Add(StartCoroutine(StopAlarm()));
        }
    }

    private void StopRunningCoroutine()
    {
        foreach (Coroutine coroutine in _startCoroutines)
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }
        }
        _startCoroutines.Clear();
    }

    private IEnumerator StartAlarm()
    {
        while (_alarm.volume < _volumeMax)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, _volumeMax, _volumeStep);
            yield return _delay;
        }
    }

    private IEnumerator StopAlarm()
    {
        while (_alarm.volume > _volumeMin)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, _volumeMin, _volumeStep);
            yield return _delay;
        }
        _alarm.Stop();
    }

    private IEnumerator ColorSignaling()
    {
        while (_isActivated)
        {
            _renderer.color = Color.red;
            yield return _delay;
            _renderer.color = Color.white;
            yield return _delay;
        }
    }
}
