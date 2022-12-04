using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Keyboard input.
    private float _inputHorizontal;
    private float _inputVertical;
    
    // Mouse input.
    private Vector3 _mousePos;
    private bool _mouseClick;

    void Update()
    {
        // Get keyboard input.
        _inputHorizontal = Input.GetAxisRaw("Horizontal");
        _inputVertical = Input.GetAxisRaw("Vertical");

        // Get mouse position.
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.z = 10f;

        // Get mouse click.
        _mouseClick = Input.GetMouseButton(0);
    }

    public Vector2 GetMoveInput()
    {
        return new Vector2(_inputHorizontal, _inputVertical);
    }

    public Vector2 GetMousePos()
    {
        return _mousePos;
    }

    public bool GetMouseClick()
    {
        return _mouseClick;
    }
}
