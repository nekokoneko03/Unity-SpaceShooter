using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable objects/TEST")]
public class PickupEffect_AddExp : PickupEffect_Base
{
    public int exp;

    public override void Effect(GameObject target)
    {
        target.GetComponent<ILevelUpable>()?.AddExp(exp);
    }
}
