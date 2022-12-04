using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class OnDeathEffect_DropGameObject : OnDeathEffect_Base
{
    public GameObject gameObjectToDrop;

    public override void Execute(GameObject target)
    {
        Instantiate(gameObjectToDrop, target.transform.position, Quaternion.identity);
    }
}
