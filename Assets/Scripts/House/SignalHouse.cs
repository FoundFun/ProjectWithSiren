using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SignalHouse : MonoBehaviour
{
    private AudioSource _audioSource;
    private Coroutine _coroutine;
    private float stepVolume = 0.1f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void isSignal(float target, bool isPlay)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        if (isPlay)
        {
            _coroutine = StartCoroutine(Enabling(target));
        }
        else
        {
            _coroutine = StartCoroutine(Shutdown(target));
        }
    }

    private IEnumerator Enabling(float target)
    {
        var downtime = new WaitForSeconds(1f);
        _audioSource.Play();

        while (_audioSource.volume < target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, stepVolume);

            yield return downtime;
        }
    }

    private IEnumerator Shutdown(float target)
    {
        var downtime = new WaitForSeconds(1f);

        while (_audioSource.volume > target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, stepVolume);

            yield return downtime;
        }

        _audioSource.Stop();
    }
}