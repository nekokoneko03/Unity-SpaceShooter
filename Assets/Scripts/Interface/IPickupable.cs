using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickupable
{
    public IPickupEffect PickupEffect { get; }
    public void OnPickup(GameObject target);
}
