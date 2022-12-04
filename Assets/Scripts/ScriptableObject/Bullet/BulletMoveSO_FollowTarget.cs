using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu]
public class BulletMoveSO_FollowTarget : BulletMoveSO
{
    [SerializeField] private float speedMultiplier;

    public override void Stop(Rigidbody2D rb2d)
    {
        rb2d.velocity = Vector2.zero;
    }

    public override void Move(GameObject bullet, GameObject target, float speed)
    {
        bullet.transform.position = Vector2.MoveTowards(bullet.transform.position, target.transform.position, speed * speedMultiplier * Time.deltaTime);

        Vector3 direction = target.transform.position - bullet.transform.position;
        bullet.transform.rotation = Quaternion.FromToRotation(Vector2.up, direction);
    }
}
