using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IPickupable
{
    [SerializeField] private float _approachDist;
    [SerializeField] private float _approachSpeed;
    [SerializeField] private float _getDistance;

    [SerializeField] private PickupEffect_Base _pickupEffect;

    [SerializeField] private LayerMask _targetLayer;

    public IPickupEffect PickupEffect { get => _pickupEffect; }

    private void Start()
    {
        _getDistance = Mathf.Clamp(_getDistance, 0.1f, 0.3f); // Convert distance to get item to 0.1f ~ 0.3f;
    }

    private void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, _approachDist, _targetLayer);

        if (collider != null)
        {
            MoveTowardTarget(collider.gameObject);
            CheckTargetDistance(collider.gameObject);
        }
    }

    private void MoveTowardTarget(GameObject target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, _approachSpeed * Time.deltaTime);
    }

    private void CheckTargetDistance(GameObject target)
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance >= _getDistance) return;

        if (target.GetComponent<IItemPicker>() != null)
        {
            target.GetComponent<IItemPicker>().PickUp(this);
        }
    }

    public void OnPickup(GameObject target)
    {
        _pickupEffect.Effect(target);
        Destroy(this.gameObject);
    }
}
