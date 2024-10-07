using System;
using UnityEngine;

public abstract class Missile : MonoBehaviour, IReflectable
{
    public event Action OnReflected;

    [SerializeField] protected Rigidbody _rigidbody;

    [SerializeField] protected float _speed = 40f;

    private bool _isReflected = false;

    public bool IsReflected => _isReflected;

    protected void Initialize(float speed)
    {
        _speed = speed;
    }

    protected virtual void Move()
    {
        _rigidbody.velocity = transform.forward * _speed;
    }

    public void ReflectionMove(Vector3 direction)
    {
        if (_isReflected == true)
        {
            Debug.Log("��� ��������");
            return;
        }

        _isReflected = true;

        OnReflected?.Invoke();

        Vector3 newDirection = direction - transform.position;
        newDirection.Normalize();

        _rigidbody.MoveRotation(Quaternion.LookRotation(newDirection));
    }
}
