using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyStats : ScriptableObject
{
    public int maxHp;
    public float speed;

    public List<OnDeathEffect_Base> onDeathEffects;

    [Header("Weapon")]
    public Weapon_Base weapon;
}
