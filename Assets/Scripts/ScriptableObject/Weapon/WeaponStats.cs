using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New weapon", menuName = "Scriptable objects/New weapon")]
public class WeaponStats : ScriptableObject
{
    [Header("Item info")]
    public Image icon;
    public new string name;
    public WeaponTargetType target;

    [Header("Rate of fire")]
    public ShotType shotType;
    public float shotDelay;
    public int burstCount;
    public float burstDelay;

    [Header("If shot type is multi, edit the following items. ")]
    public float bulletCount;
    public int bulletAngle;

    [Header("Bullet")]
    public BulletStats bulletStats;
}

public enum WeaponTargetType
{
    ClosestEnemy,
    Player
}

public enum ShotType
{
    Single,
    Multi
}