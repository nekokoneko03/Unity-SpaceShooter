using System.Threading.Tasks;
using UnityEngine;

public class Weapon_Base : MonoBehaviour, IUpgradeableWeapon
{
    [SerializeField] private WeaponStats _stats;

    private IShot _shot;
    private IBulletMove _bulletMove;

    private bool _canShot;

    private void Start()
    {
        ShotDelay(_stats.shotDelay);

        _bulletMove = GetComponent<IBulletMove>();

        _shot = GetShotType(_stats.shotType);

        _bulletMove ??= new BulletMove_Straight();
    }

    public IShot GetShotType(ShotType type)
    {
        switch (_stats.shotType)
        {
            case ShotType.Single:
                return new Shot_Single();
            case ShotType.Multi:
                return new Shot_Multi();
            default:
                return new Shot_Single();
        }
    }

    public void DoShot(Transform shotPoint)
    {
        if (!_canShot) return;

        switch (_stats.target)
        {
            case WeaponTargetType.Player:
                _shot.Shot(shotPoint, GameObject.FindGameObjectWithTag("Player"), _stats.bulletStats, _stats);
                break;
            case WeaponTargetType.ClosestEnemy:
                _shot.Shot(shotPoint, FindNearestEnemy.instance.GetNearestEnemy(Camera.main.ScreenToWorldPoint(Input.mousePosition)), _stats.bulletStats, _stats);
                break;
        }

        ShotDelay(_stats.shotDelay);
    }

    async void ShotDelay(float delay)
    {
        int delayTime = (int)(delay * 1000);

        _canShot = false;
        await Task.Delay(delayTime);
        _canShot = true;
    }

    public void SetWeaponStats(WeaponStats newStats)
    {
        _stats = newStats;

        _shot = GetShotType(newStats.shotType);
    }
}