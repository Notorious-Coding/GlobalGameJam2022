using UnityEditor;
using UnityEngine;

public class BasicSpellState : State
{

    [SerializeField] protected ProjectileSpell _basicSpell;
    [SerializeField] protected Animator _animator;
    public override void HandleLogic()
    {
        if (!IsStateComplete)
        {
            _animator.SetTrigger("Attack1");
        }
        IsStateComplete = true;
    }

    public override void HandlePhysicsLogic()
    {
        return;
    }

    public void Fire()
    {
        _basicSpell.Fire();
    }
}
