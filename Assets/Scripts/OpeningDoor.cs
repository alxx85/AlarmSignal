﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class OpeningDoor : MonoBehaviour
{
    [SerializeField] private UnityEvent _usingDoor;

    private Animator _animator;

    private const string Action = "Activate";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ThiefMove>(out ThiefMove thief))
        {
            _animator.SetTrigger(Action);
            _usingDoor?.Invoke();
        }
    }
}
