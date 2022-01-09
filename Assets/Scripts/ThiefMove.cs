using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ThiefMove : MonoBehaviour
{
    [SerializeField] private Targets _possibleTargets;
    [SerializeField] private float Speed;

    private Animator _animator;
    private Transform _target;
    private Vector3 _doorPosition;
    private float _targetPosition;
    private bool _isStolen;
    private bool _isInMove;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _doorPosition = transform.position;
        _target = _possibleTargets.SetNewTarget();
        _targetPosition =_target.position.x;
        _isInMove = true;
    }

    private void Update()
    {
        if (_isInMove)
            Moving();
    }

    public void TimeToSteal()
    {
        _isInMove = false;
        _animator.SetFloat("Speed", 0);
        _animator.SetTrigger("Steal");
    }

    private void Moving()
    {
        float distance;
        if (_isStolen)
        {
            distance = Mathf.Abs(_doorPosition.x - transform.position.x);
            if (distance > 0)
            {
                transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, _doorPosition.x, Speed * Time.deltaTime),
                                                 transform.position.y, 0);
            }
            else
            {
                _isInMove = false;
                Destroy(gameObject);
            }
        }
        else
        {
            distance = Mathf.Abs(_targetPosition - transform.position.x);
            if (distance > 0)
            {
                transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, _targetPosition, Speed * Time.deltaTime),
                                                 transform.position.y, 0);
            }
        }
        _animator.SetFloat("Speed", distance);
    }

    private void SetStolen()
    {
        _isStolen = true;
        Destroy(_target.gameObject);
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 0);
        _isInMove = true;
    }
}
