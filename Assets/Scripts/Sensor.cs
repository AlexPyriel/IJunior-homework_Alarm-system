using UnityEngine;
using UnityEngine.Events;

public class Sensor : MonoBehaviour
{
    [SerializeField] private UnityEvent _movementDetected;
    [SerializeField] private UnityEvent _areaSecured;

    private void OnTriggerEnter(Collider other)
    {
        _movementDetected?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        _areaSecured?.Invoke();
    }
}
