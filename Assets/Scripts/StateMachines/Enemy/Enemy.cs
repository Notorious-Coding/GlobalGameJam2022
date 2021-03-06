using UnityEngine;

public class Enemy : StateMachine, ITargetLock
{
    [SerializeField]
    Transform _chaman;

    [SerializeField] GameObject _explosionEffect;

    void Awake()
    {
        _explosionEffect.SetActive(false);
    }

    public void Start()
    {
        SetState(GetState<WalkTo>());
    }

    public void Update()
    {
        // Dès qu'on est assez proche du chaman
        if(Vector3.Distance(_chaman.position, transform.position) <= 2)
        {
            //Si on est pas en état d'explosion ou mort, alors on explose.
            if(!(CurrentState is Explode) && !(CurrentState is Die))
                SetState(GetState<Explode>());

            //Si on a fini d'exploser, on meurt.
            if(CurrentState is Explode && CurrentState.IsStateComplete)
            {
                SetState(GetState<Die>());
            }
        }
        CurrentState.HandleLogic();
    }

    public void FixedUpdate()
    {
        CurrentState.HandlePhysicsLogic();
    }

    public void LockTarget(Entity entity)
    {
        _chaman = entity.transform;
        GetState<WalkTo>().LockTarget(entity);
        GetState<Explode>().LockTarget(entity);
    }
}

