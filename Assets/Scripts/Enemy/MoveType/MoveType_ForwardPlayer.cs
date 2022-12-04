using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveType_ForwardPlayer : MonoBehaviour, IMove
{
    [SerializeField] private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Move(float speed)
    {
        if (_player == null) return;

        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, speed * Time.deltaTime);
    }
}
