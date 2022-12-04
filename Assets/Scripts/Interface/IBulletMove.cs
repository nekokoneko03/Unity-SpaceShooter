using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBulletMove
{
    public void Stop(Rigidbody2D rb2d);
    public void Move(GameObject bullet, GameObject target, float speed);
}
