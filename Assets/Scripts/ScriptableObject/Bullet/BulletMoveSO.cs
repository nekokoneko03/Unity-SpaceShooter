using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletMoveSO : ScriptableObject, IBulletMove
{
    public abstract void Stop(Rigidbody2D rb2d);

    public abstract void Move(GameObject bullet, GameObject target, float speed);
}
