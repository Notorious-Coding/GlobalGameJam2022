using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WalkTo : State, ITargetLock
{

    [SerializeField] private Rigidbody _rigibody;
    [SerializeField] private Entity _target;
    [SerializeField] private float _speed;

    public override void HandleLogic()
    {
    }

    public override void HandlePhysicsLogic()
    {
        transform.LookAt(new Vector3(_target.transform.position.x, transform.position.y, _target.transform.position.z));
        _rigibody.MovePosition(transform.position + (transform.forward * _speed * Time.fixedDeltaTime));
    }

    public void LockTarget(Entity target)
    {
        _target = target;
    }
}

