using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement status.
    [SerializeField] private float _speed;
    [SerializeField] private float _stopTime;

    // Stage limit.
    [SerializeField] private Transform _bottomLeft;
    [SerializeField] private Transform _topRight;

    // Movement stuff.
    private Rigidbody2D _rb2d;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 input)
    {
        if (input.x != 0 || input.y != 0)
        {
            if (_rb2d.velocity.magnitude <= 10f)
            {
                _rb2d.AddForce((input.normalized) * _speed);
            }
        }
        else
        {
            if (_rb2d.velocity != Vector2.zero)
            {
                Vector2 test = new Vector2(_rb2d.velocity.x / (_stopTime * 60), _rb2d.velocity.y / (_stopTime * 60));
                _rb2d.velocity -= test;
            }
        }

        CheckLoop();
    }

    private void CheckLoop()
    {
        // Predict position 0.02sec later.
        float xPosition = (_rb2d.velocity.x / _rb2d.mass) * Time.deltaTime; // Speed * time.
        float yPosition = (_rb2d.velocity.y / _rb2d.mass) * Time.deltaTime;

        // Check x-axis.
        if (transform.position.x <= _bottomLeft.position.x)
        {
            transform.position = new Vector2(_topRight.position.x, transform.position.y + yPosition);
        }
        else if (transform.position.x >= _topRight.position.x)
        {
            transform.position = new Vector2(_bottomLeft.position.x, transform.position.y + yPosition);
        }

        // Check y-axis.
        if (transform.position.y <= _bottomLeft.position.y)
        {
            transform.position = new Vector2(transform.position.x + xPosition, _topRight.position.y);
        }
        else if (transform.position.y >= _topRight.position.y)
        {
            transform.position = new Vector2(transform.position.x + xPosition, _bottomLeft.position.y);
        }
    }

    public void LookAtMouse(Vector3 position)
    {
        Vector3 direction = (position - transform.position).normalized;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
    }
}
