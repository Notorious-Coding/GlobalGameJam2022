using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _moveSpeed = 2.0f;
    Vector2 _moveInput; 

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(_moveInput.x, 0, _moveInput.y) * _moveSpeed * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext ctx) => _moveInput = ctx.ReadValue<Vector2>();
}
