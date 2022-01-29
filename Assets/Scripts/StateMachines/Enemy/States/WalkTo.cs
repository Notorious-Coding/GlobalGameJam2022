using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WalkTo : State
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private Rigidbody _rigibody;

    [SerializeField]
    private float _speed;


    public override void HandleLogic()
    {
    }

    public override void HandlePhysicsLogic()
    {
        var direction = (_target.position - transform.position).normalized;
        transform.LookAt(new Vector3(_target.transform.position.x, transform.position.y, _target.transform.position.z));
        _rigibody.MovePosition(transform.position + (transform.forward * _speed * Time.fixedDeltaTime));
    }
}

