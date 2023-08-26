using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSwitch : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    
    private float _maxVolume;
    private float _changeVolumeSpeed = 0.5f;
    private Coroutine _activeCoroutine;

    private void Start()
    {
        _audioSource.volume = 0;
    }

    public void PlaySignal()
    {
        _maxVolume = 1f;
        _audioSource.Play();
        _activeCoroutine = StartCoroutine(ChangeVolume());
    }

    public void OffSignal()
    {
        _maxVolume = 0f;
        StopCoroutine(_activeCoroutine);
        _activeCoroutine = StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        while(_audioSource.volume != _maxVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _changeVolumeSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
