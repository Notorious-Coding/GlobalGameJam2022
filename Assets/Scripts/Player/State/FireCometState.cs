using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireCometState : State
{
    private Vector2 _moveTargetedZoneInput = Vector2.zero;
    [SerializeField] GameObject _targetedZonePrefab;
    GameObject _targetedZone;
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] float _targetedZoneSpeed;
    [SerializeField] private Animator _animator;
    [SerializeField] private ElementalBalanceSO _elementalBalanceSO;
    [SerializeField] private SpellSO _spellData;


    public override void OnStateEnter()
    {
        _targetedZone = Instantiate(_targetedZonePrefab, this.transform.position, Quaternion.identity);
        IsStateComplete = false;
    }

    public override void HandleLogic()
    {
    }

    public override void HandlePhysicsLogic()
    {
        if(!_targetedZone) return;
        transform.LookAt(_targetedZone.transform);
        _targetedZone.transform.Translate(new Vector3(_moveTargetedZoneInput.x, 0, _moveTargetedZoneInput.y) * _targetedZoneSpeed * Time.fixedDeltaTime);
    }

    public override void OnStateExit()
    {
        _animator.SetTrigger("Attack2");
    }

    public void FireComet()
    {
        _elementalBalanceSO.OnSpellLaunch(_spellData);
        Instantiate(_projectilePrefab, _targetedZone.transform.position, Quaternion.identity);
        Destroy(_targetedZone,0.5f);
    }
    

    public void OnTurn(InputAction.CallbackContext ctx)
    {
        _moveTargetedZoneInput = ctx.ReadValue<Vector2>();
    }

    public void OnValidateMassiveSpell(InputAction.CallbackContext ctx)
    {
        IsStateComplete = true;
    }
}
