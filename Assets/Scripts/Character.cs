
using System.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private float _speed;
    [SerializeField] private float _acceleration;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _renderer;

    public int GetId() => _id;

    private Vector3 _direction = Vector3.forward;
    private float _currentSpeed = 0f;
    private bool _updateSpeed = false;

    public float GetCurrentNormalizedSpeed()
    {
        if (_speed <= 0) return 0f;
        return Mathf.Clamp01(_currentSpeed / _speed);
    }

    public void MoveInDirection(Vector3 direction){
        direction.y = 0f;
        direction.Normalize();
        _direction = direction;
        _updateSpeed = true;
    }

    void Update(){
        if(_id > 0){
            _renderer.rotation = Quaternion.Slerp(_renderer.rotation,  Quaternion.LookRotation(_direction), Time.deltaTime * 30f);
        }
    }

    void LateUpdate()
    {
        if(_id > 0){
            _currentSpeed = Mathf.Lerp(_currentSpeed, _updateSpeed ? _speed : 0f, Time.deltaTime * _acceleration);
            _updateSpeed = false;
        }
    }

    private void FixedUpdate()
    {
        if(_id > 0){
            _rigidbody.velocity = _direction * _currentSpeed;
        }   
    }
}
