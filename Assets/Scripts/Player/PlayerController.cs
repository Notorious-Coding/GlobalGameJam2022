using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : StateMachine
{
    [Header("Mouvement")]
    [SerializeField] Rigidbody _rigidbody;
    Vector2 _moveInput;
    Vector2 _turnInput;
    [SerializeField] private Cooldown _attackRate;
    [SerializeField] ElementalPlayerSO _elementalPlayerData;
    [SerializeField] ElementalBalanceSO _elementalBalanceData;
    [SerializeField]
    public List<StatusSO> possibleStatus;
    [SerializeField] private Animator _animator;

    private float _initialAttackRate;
    private float _currentMoveSpeed;
    private float _currentStepIntensity = 0;
    protected void Awake()
    {
        SetState(GetState<DefaultState>());
    }

    private void Start()
    {
        _initialAttackRate = _attackRate._cooldown;
        _currentMoveSpeed = _elementalPlayerData.MoveSpeed;
        _elementalBalanceData.SubscribeToElementalBalanceStatusChange(ManageStatusChange);
    }

    private void ManageStatusChange(StatusGameEventData eventData)
    {
        StatusSO currentStatus = possibleStatus.FirstOrDefault(status => status.statusBound.Equals(eventData.Status));

        if(currentStatus != null)
        {
            switch (currentStatus.statusBound)
            {
                case StatusEnum.Water:
                    _attackRate._cooldown = _initialAttackRate + ( eventData.IntensityIndex * currentStatus.statusIntensityIncrementValue);
                    break;
                default:
                    _attackRate._cooldown = _initialAttackRate;
                    break;
            }
        } else
        {
            _currentMoveSpeed = _elementalPlayerData.MoveSpeed;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!(CurrentState is StunState))
        {
            Move();
            Turn();
        }

        CurrentState.HandlePhysicsLogic();
    }

    protected void Update()
    {

        if (CurrentState.IsStateComplete && CurrentState is StunState)
            SetState(GetState<DefaultState>());
        
        // Si on tirer un basic spell et qu'il est terminé
        if(CurrentState.IsStateComplete && CurrentState is BasicSpellState)
        {
            SetState(GetState<DefaultState>());
        }
        CurrentState.HandleLogic();
    }

    public void Move()
    {
        _rigidbody.MovePosition(this.transform.position + new Vector3(_moveInput.x, 0, _moveInput.y) * _currentMoveSpeed * Time.deltaTime);
        _animator.SetFloat("Walking",Mathf.Max(Mathf.Abs(_moveInput.x), Mathf.Abs(_moveInput.y)));
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
        if (_attackRate.isEnded && !(CurrentState is StunState))
        {
            _elementalBalanceData.OnSpellLaunch(_elementalPlayerData.BasicSpellData);
            SetState(GetState<BasicSpellState>());
            _attackRate.Stop();
            _attackRate.Start();
        }
    }

    public void Stun()
    {
        SetState(GetState<StunState>());
    }
}
