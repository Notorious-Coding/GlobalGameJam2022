using UnityEditor;
using UnityEngine;

public class BasicSpellState : State
{

    [SerializeField] ProjectileSpell _basicSpell;
    public override void HandleLogic()
    {
        if (!IsStateComplete)
        {
            _basicSpell.Fire();
        }
        IsStateComplete = true;
    }

    public override void HandlePhysicsLogic()
    {
        return;
    }
}
