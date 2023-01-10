using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SignalHouse : MonoBehaviour
{
    private AudioSource _audioSource;
    private bool _isPlay;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_isPlay == true)
        {
            ChangeSound(1);
        }
        else if (_isPlay == false && _audioSource.volume > 0)
        {
            ChangeSound(-1);
        }
    }

    private void ChangeSound(int polarity)
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 1, 0.1f * Time.deltaTime * polarity);
    }

    public void Play()
    {
        _isPlay = true;
        _audioSource.Play();
    }

    public void Stop()
    {
        _isPlay = false;

        if (_audioSource.volume == 0)
        {
            _audioSource.Stop();
        }
    }
}
