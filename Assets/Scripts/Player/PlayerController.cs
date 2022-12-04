using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(PlayerMovement), typeof(PlayerAttack))]
[RequireComponent(typeof(PlayerHealth))]
public class PlayerController : MonoBehaviour, IDamageable, IItemPicker, ILevelUpable
{
    private PlayerInput _playerInput;
    private PlayerMovement _playerMovement;
    private PlayerAttack _playerAttack;
    private PlayerHealth _playerHealth;
    private PlayerLevel _playerLevel;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAttack = GetComponent<PlayerAttack>();
        _playerHealth = GetComponent<PlayerHealth>();
        _playerLevel = GetComponent<PlayerLevel>();
    }

    private void Update()
    {
        // Player movement.
        Vector2 input = _playerInput.GetMoveInput();
        _playerMovement?.Move(input);

        // Player rotation to mouse position.
        Vector3 mousePos = _playerInput.GetMousePos();
        _playerMovement?.LookAtMouse(mousePos);

        // Player shot.
        bool mouseClick = _playerInput.GetMouseClick();
        _playerAttack?.Attack(mouseClick);
    }

    public void TakeDamage(int damage)
    {
        _playerHealth.TakeDamage(damage);
    }

    public void AddExp(int value)
    {
        _playerLevel.AddExp(value);
    }

    public void PickUp(Item item)
    {
        item.GetComponent<IPickupable>().OnPickup(this.gameObject);
    }
}
