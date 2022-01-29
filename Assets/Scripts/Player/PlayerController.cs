using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Mouvement")]
    [SerializeField]
    float _moveSpeed = 2.0f;
    [SerializeField] Rigidbody _rigidbody;
    Vector2 _moveInput;
    Vector2 _turnInput;

    [Header("Attaques simple")]
    [SerializeField] Cooldown _attackRate;
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] Transform _firePoint;



    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.MovePosition(this.transform.position + new Vector3(_moveInput.x, 0, _moveInput.y) * _moveSpeed * Time.deltaTime);
        var fwd = new Vector3(_turnInput.x, 0, _turnInput.y);
        transform.forward = fwd;
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        _moveInput = ctx.ReadValue<Vector2>();
    }

    public void OnTurn(InputAction.CallbackContext ctx)
    {
        _turnInput = ctx.ReadValue<Vector2>();
    }

    public void OnFire(InputAction.CallbackContext ctx)
    {
        if (_attackRate.isEnded)
        {
            Fire();
            _attackRate.Stop();
            _attackRate.Start();
        }
    }

    public void Fire()
    {
        var projectile = Instantiate(_projectilePrefab, _firePoint.position, _firePoint.rotation);
    }
}
