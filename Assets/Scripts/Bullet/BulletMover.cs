using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField] private BulletMoveSO _move;
    [SerializeField] private BulletStats _stats;

    private GameObject _target;

    private float _stopDelayTimer;
    private float _resumeMoveDelayTimer;

    public void SetMove(BulletMoveSO move)
    {
        _move = move;
    }

    public void SetBulletStats(BulletStats stats)
    {
        _stats = stats;
    }

    public void SetTarget(GameObject target)
    {
        _target = target;
    }

    public void DoMove()
    {
        if (_stopDelayTimer >= _stats.bulletStopDelay)
        {
            _move?.Stop(GetComponent<Rigidbody2D>());

            if (_resumeMoveDelayTimer >= _stats.bulletResumeMoveDelay)
            {
                if (_target != null)
                {
                    _move?.Move(this.gameObject, _target, _stats.bulletSpeed);
                }
                else
                {
                    _target = FindNearestEnemy.instance.GetNearestEnemy(this.gameObject.transform.position);
                    if (_target == null)
                    {
                        // TODO: Destroy when only bullet move type is follow target.
                    }
                    else
                    {
                        _move?.Move(this.gameObject, FindNearestEnemy.instance.GetNearestEnemy(this.gameObject.transform.position), _stats.bulletSpeed);
                    }
                }
            }

            _resumeMoveDelayTimer += Time.deltaTime;
        }
        _stopDelayTimer += Time.deltaTime;
    }
}
