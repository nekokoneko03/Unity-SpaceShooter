using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade_Base : ScriptableObject, IUpgrade
{
    public abstract void Upgrade(GameObject target);
}
