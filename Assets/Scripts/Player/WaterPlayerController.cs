using UnityEngine;
using UnityEngine.InputSystem;

public class WaterPlayerController : PlayerController
{
    [SerializeField] Cooldown _massiveSpellcooldown;
    private void Awake()
    {
        SetState(GetState<DefaultState>());
    }

    void FixedUpdate()
    {
        Move();
        Turn();

        CurrentState.HandlePhysicsLogic();
    }


    private void Update()
    {
        if (CurrentState is BasicSpellState && CurrentState.IsStateComplete)
        {
            SetState(GetState<DefaultState>());
        }

        CurrentState.HandleLogic();
    }
}
