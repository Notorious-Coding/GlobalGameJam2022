
using UnityEngine;

public class Die : State
{
    [SerializeField] Cooldown _deathTime;

    public override void HandleLogic()
    {
        //On joue l'animation de mort, puis on detruit le GO;
        if (_deathTime.isEnded && !IsStateComplete)
        {
            Destroy(this.gameObject);
            IsStateComplete = true;
        }
    }

    public override void HandlePhysicsLogic()
    {
        return;
    }

    public override void OnStateEnter()
    {
        _deathTime.Start();
        base.OnStateEnter();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }
}

