using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _recoveryRate = 0.5f;

    private AudioSource _audioSource;
    private Coroutine _activeCoroutine;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private IEnumerator FadeIn()
    {
        _audioSource.Play();
        _audioSource.volume = _minVolume;
        while (_audioSource.volume < _maxVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _recoveryRate * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        _audioSource.Play();
        while (_audioSource.volume > _minVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _minVolume, _recoveryRate * Time.deltaTime);
            yield return null;
        }
        _audioSource.Stop();
    }

    public void Enable()
    {
        if (_activeCoroutine != null)
            StopCoroutine(_activeCoroutine);
        _activeCoroutine = StartCoroutine(FadeIn());
    }

    public void Disable()
    {
        if (_activeCoroutine != null)
            StopCoroutine(_activeCoroutine);
        _activeCoroutine = StartCoroutine(FadeOut());
    }
}
