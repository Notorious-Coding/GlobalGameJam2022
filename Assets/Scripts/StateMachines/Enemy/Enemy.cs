using UnityEngine;

public class Enemy : StateMachine, ITargetLock
{
    [SerializeField]
    Transform _chaman;

    [SerializeField] GameObject _explosionEffect;
    [SerializeField] float life;
    [SerializeField] private float _range;

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
        if(life <= 0 && !(CurrentState is Die))
        {
            SetState(GetState<Die>());
        }
        // Dès qu'on est assez proche du chaman
        if(Vector3.Distance(_chaman.position, transform.position) <= _range)
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

    public void TakeDamage(float amount)
    {
        life -= amount;
    }
}

