using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ThiefMover : MonoBehaviour
{
    [SerializeField] private Targets _possibleTargets;
    [SerializeField] private float _speed;

    private Animator _animator;
    private Transform _target;
    private Vector3 _doorPosition;
    private float _targetPosition;
    private bool _isTargetStolen;
    private bool _isInMove;

    private const string Move = "Speed";
    private const string Active = "Steal";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _doorPosition = transform.position;
        _target = _possibleTargets.GetTargetTransform();
        Debug.Log(_target.name);
        _targetPosition =_target.position.x;
        _isInMove = true;
    }

    private void Update()
    {
        if (_isInMove)
            ChangePosition();
    }

    public void TimeToSteal()
    {
        _isInMove = false;
        _animator.SetFloat(Move, 0);
        _animator.SetTrigger(Active);
    }

    private void ChangePosition()
    {
        float distance;
        if (_isTargetStolen)
        {
            distance = Mathf.Abs(_doorPosition.x - transform.position.x);
            if (distance > 0)
            {
                transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, _doorPosition.x, _speed * Time.deltaTime),
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
                transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, _targetPosition, _speed * Time.deltaTime),
                                                 transform.position.y, 0);
            }
        }
        _animator.SetFloat(Move, distance);
    }

    private void IsStolen()
    {
        _isTargetStolen = true;
        Destroy(_target.gameObject);
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 0);
        _isInMove = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ThiefPurpose>(out ThiefPurpose target))
        {
            if (target.IsTarget)
            {
                TimeToSteal();
            }
        }
    }
}
