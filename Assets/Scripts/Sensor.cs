using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Sensor : MonoBehaviour
{
    [SerializeField] private UnityEvent _detected;
    [SerializeField] private UnityEvent _cleared;

    private void OnTriggerEnter(Collider other)
    {
        _detected?.Invoke();

    }

    private void OnTriggerExit(Collider other)
    {
        _cleared?.Invoke();
    }
}
