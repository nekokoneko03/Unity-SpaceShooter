using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupEffect_Base : ScriptableObject, IPickupEffect
{
    public abstract void Effect(GameObject target);
}
