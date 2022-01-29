using UnityEngine;

public class Enemy : StateMachine
{
    [SerializeField]
    Transform _chaman;
    public void Start()
    {
        SetState(GetState<WalkTo>());
    }

    public void Update()
    {
        if(Vector3.Distance(_chaman.position, transform.position) <= 2)
        {
            SetState(GetState<Explode>());
        }
        CurrentState.HandleLogic();
    }

    public void FixedUpdate()
    {
        CurrentState.HandlePhysicsLogic();
    }
}

