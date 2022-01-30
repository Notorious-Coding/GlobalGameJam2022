using UnityEditor;
using UnityEngine;

public class StunState : State
{
    [SerializeField]
    private Cooldown _stunTime; 

    public override void HandleLogic()
    {
        if (_stunTime.isEnded && !IsStateComplete)
        {
            IsStateComplete = true;
        }
    }

    public override void HandlePhysicsLogic()
    {
        return;
    }

    public override void OnStateEnter()
    {
        _stunTime.Start();
        base.OnStateEnter();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }
}
