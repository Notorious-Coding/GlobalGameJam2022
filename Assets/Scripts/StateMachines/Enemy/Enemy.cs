using UnityEngine;

public class Enemy : StateMachine
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
        Debug.Log(CurrentState);
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
}

