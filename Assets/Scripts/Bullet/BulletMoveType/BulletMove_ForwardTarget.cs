using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BulletMove_ForwardTarget : MonoBehaviour, IBulletMove
{
    [SerializeField] private TargetType _targetType;
    [SerializeField] private float _speedMultiplier;
    [SerializeField] private float _stopDelay;
    [SerializeField] private float _moveDelay;

    private float _speed; // Initialized by start method.

    // target
    private GameObject _target;
    private Bullet _bullet;

    // positions
    private Vector2 _startPosition;
    private Vector2 _targetPosition;
    private float _distance;
    private float _rate;
    private float _negativeRate;

    // timers
    private float _stopTimer;
    private float _moveTimer;
    private float _elapsedTime;

    // initialize
    private bool _initialized;

    private void Start()
    {
        _initialized = false;
    }

    public void Initialize(Bullet bullet)
    {
        switch (_targetType)
        {
            case TargetType.Player:
                _target = GameObject.FindGameObjectWithTag("Player");
                break;
            case TargetType.Enemy:
                _target = GameObject.FindGameObjectWithTag("Enemy");
                break;
        }

        _bullet = bullet;
        _speed = _bullet.GetComponent<Rigidbody2D>().velocity.magnitude * _speedMultiplier;
    }

    public void Move(GameObject bullet, GameObject target, float speed)
    {
        _stopTimer += Time.deltaTime;

        if (_stopTimer >= _stopDelay)
        {
            _moveTimer += Time.deltaTime;

            if (_moveTimer >= _moveDelay)
            {
                if (!_initialized)
                {
                    _initialized = true;
                    bullet.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    _startPosition = bullet.transform.position;
                    _targetPosition = _target.transform.position;
                    _distance = Vector2.Distance(_startPosition, _targetPosition);
                }

                transform.position = Vector2.MoveTowards(_startPosition, _targetPosition, speed * Time.deltaTime);

                if (new Vector2(transform.position.x, transform.position.y) == _targetPosition)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }

    public void Stop(Rigidbody2D rb2d)
    {
        throw new System.NotImplementedException();
    }
}
