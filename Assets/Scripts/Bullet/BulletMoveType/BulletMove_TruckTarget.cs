using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BulletMove_TruckTarget : MonoBehaviour, IBulletMove
{
    [SerializeField] private TargetType _targetType;
    [SerializeField] private float _speedMultiplier;
    [SerializeField] private float _stopDelay;
    [SerializeField] private float _moveDelay;
    [SerializeField] private float _trackTime;

    private float _speed; // Initialized by start method.

    // target
    private GameObject _target;
    private Bullet _bullet;

    // positions
    private Vector2 _startPosition;
    private float _distance;
    private float _rate;

    // timers
    private float _stopTimer;
    private float _moveTimer;
    private float _destroyTimer;
    private float _elapsedTime;

    // initialize
    private bool _initialized;
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

        _initialized = false;
        _speed = GetComponent<Rigidbody2D>().velocity.magnitude * _speedMultiplier;
    }

    public void Move(GameObject bullet, GameObject target, float speed)
    {
        if (_target == null) return;

        _stopTimer += Time.deltaTime;

        if (_stopTimer >= _stopDelay)
        {
            _moveTimer += Time.deltaTime;

            if (!_initialized)
            {
                _initialized = true;
                _bullet.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                _startPosition = _bullet.transform.position;
                _distance = Vector2.Distance(_startPosition, _target.transform.position);
            }

            if (_moveTimer >= _moveDelay)
            {
                _destroyTimer += Time.deltaTime;
                _elapsedTime += Time.deltaTime;
                _rate = Mathf.Clamp01((_elapsedTime * _speed) / _distance);
                transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
                transform.rotation = Quaternion.FromToRotation(Vector2.up, _target.transform.position - this.transform.position);
            }
        }
    }

    public void Stop(Rigidbody2D rb2d)
    {
        throw new System.NotImplementedException();
    }
}

public enum TargetType
{
    Player,
    Enemy
}
