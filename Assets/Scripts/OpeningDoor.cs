using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class OpeningDoor : MonoBehaviour
{
    [SerializeField] private UnityEvent _usingDoor;
    private Animator animator;
    private bool _isInside;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ThiefMove>(out ThiefMove thief))
        {
            if (_isInside)
            {
                animator.SetTrigger("OpenDoor");
                Debug.Log("Outside");
                _isInside = false;
            }
            else
            {
                Debug.Log("Inside");
                _isInside = true;
            }
            _usingDoor?.Invoke();
        }
    }
}
