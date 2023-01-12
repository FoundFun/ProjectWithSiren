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

    public void isSignal(bool isPlay)
    {
        float target;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        if (isPlay)
        {
            target = 1f;
            _coroutine = StartCoroutine(ChangeVolume(target, isPlay));
        }
        else
        {
            target = 0f;
            _coroutine = StartCoroutine(ChangeVolume(target, isPlay));
        }
    }

    private IEnumerator ChangeVolume(float target, bool isPlay)
    {
        var downtime = new WaitForSeconds(1f);

        if (isPlay == true)
        {
            _audioSource.Play();
        }

        while (_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, stepVolume);

            yield return downtime;
        }

        if (isPlay == false)
        {
            _audioSource.Stop();
        }
    }
}