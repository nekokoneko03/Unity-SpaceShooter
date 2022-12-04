using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float _speed;
    private IMove _moveType;

    private void Start()
    {
        _moveType = GetComponent<IMove>();

        if (_moveType == null)
        {
            Debug.Log(transform.name + "has no movement type.");
        }
    }

    public void DoMove(float speed)
    {
        _moveType?.Move(speed);
    }

    public void LookPlayer(GameObject player)
    {
        Vector3 direction = player.transform.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector2.up, direction);
    }
}
