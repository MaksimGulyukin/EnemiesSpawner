using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalOfEnter : MonoBehaviour
{
    [SerializeField] private UnityEvent _entered = new UnityEvent();
    [SerializeField] private UnityEvent _leaved = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _entered?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _leaved?.Invoke();
    }
}
