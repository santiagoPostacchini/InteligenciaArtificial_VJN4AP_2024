using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private KeyCode _upKey;
    [SerializeField] private KeyCode _downKey;
    [SerializeField] private KeyCode _leftKey;
    [SerializeField] private KeyCode _rightKeys;
    private Vector3 _velocity;
    [SerializeField] private float _speed;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement(GetInput());
    }

    public void Movement(Vector3 dir)
    {
        dir.Normalize();

        _rb.MovePosition(_rb.position + _speed * Time.fixedDeltaTime * dir);
    }

    private Vector3 GetInput()
    {
        if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            _velocity.x = Input.GetAxis("Horizontal");
            _velocity.z = Input.GetAxis("Vertical");
        }
        else
        {
            _velocity = Vector3.zero;
        }

        return _velocity;
    }
}

