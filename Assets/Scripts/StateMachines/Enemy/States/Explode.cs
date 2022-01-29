
using UnityEngine;

public class Explode : State
{
    [SerializeField] int _damage;
    [SerializeField] GameObject _explosionObject;
    [SerializeField] Cooldown _explosionTime;
    [SerializeField] Entity _target;

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        _explosionObject.SetActive(true);
        _explosionTime.Start();
    }

    public override void HandleLogic()
    {
        if (_explosionTime.isEnded && !IsStateComplete)
        {
            _target.TakeDamage(_damage);
            _explosionTime.Stop();
            _explosionObject.SetActive(false);
            IsStateComplete = true;
        }
    }

    public override void HandlePhysicsLogic()
    {
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }
}

