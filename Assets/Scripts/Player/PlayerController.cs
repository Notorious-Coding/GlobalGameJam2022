using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : StateMachine
{
    [Header("Mouvement")]
    [SerializeField] Rigidbody _rigidbody;
    Vector2 _moveInput;
    Vector2 _turnInput;
    [SerializeField] ElementalPlayerSO _elementalPlayerData;
    [SerializeField] ElementalBalanceSO _elementalBalanceData;

    private void Awake()
    {
        SetState(GetState<DefaultState>());
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Turn();

        CurrentState.HandlePhysicsLogic();
    }

    protected void Update()
    {
        // Si on tirer un basic spell et qu'il est terminé
        if(CurrentState.IsStateComplete && CurrentState is BasicSpellState)
        {
            SetState(GetState<DefaultState>());
        }
        CurrentState.HandleLogic();
    }

    public void Move()
    {
        _rigidbody.MovePosition(this.transform.position + new Vector3(_moveInput.x, 0, _moveInput.y) * _elementalPlayerData.MoveSpeed * Time.deltaTime);
    }

    public void Turn()
    {
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

    public void OnFireBasicSpell(InputAction.CallbackContext ctx)
    {
        if (_elementalPlayerData.AttackRate.isEnded)
        {
            _elementalBalanceData.UpdateElementalBalanceValue(_elementalPlayerData.BasicSpellData);
            SetState(GetState<BasicSpellState>());
            _elementalPlayerData.AttackRate.Stop();
            _elementalPlayerData.AttackRate.Start();
        }
    }
}
