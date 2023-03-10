using UnityEngine;

[RequireComponent(typeof(SignalHouse))]
public class House : MonoBehaviour
{
    private SignalHouse _signal;

    private void Start()
    {
        _signal = GetComponent<SignalHouse>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _signal.isSignal(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _signal.isSignal(false);
        }
    }
}
