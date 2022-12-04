using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OnDeathEffect_Base : ScriptableObject, IOnDeathEffect
{
    public abstract void Execute(GameObject target);
}
