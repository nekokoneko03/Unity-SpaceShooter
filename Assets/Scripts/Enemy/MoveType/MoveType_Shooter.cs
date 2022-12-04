using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveType_Shooter : MonoBehaviour, IMove
{
    [SerializeField] private float _distance;

    private GameObject _player;
    private Vector3 _playerPosition;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerPosition = _player.transform.position;
    }

    public void Move(float speed)
    {
        if (Vector3.Distance(_playerPosition, transform.position) >= _distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, _playerPosition, speed * Time.deltaTime);
        }
    }
}
