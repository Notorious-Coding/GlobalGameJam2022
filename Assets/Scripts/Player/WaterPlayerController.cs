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
        if(!(CurrentState is StunState))
        {
            Move();
            Turn();
        }
        else
        {
            Debug.Log("Stun");
        }

        CurrentState.HandlePhysicsLogic();
    }


    private void Update()
    {
        if (CurrentState.IsStateComplete && CurrentState is StunState)
            SetState(GetState<DefaultState>());

        if (CurrentState is BasicSpellState && CurrentState.IsStateComplete)
        {
            SetState(GetState<DefaultState>());
        }

        CurrentState.HandleLogic();
    }

    public void OnFireMassiveSpell(InputAction.CallbackContext ctx)
    {
        if(!(CurrentState is FireWaterBallSpellState) && !(CurrentState is StunState) && _massiveSpellcooldown.isEnded)
        {
            SetState(GetState<FireWaterBallSpellState>());
            _massiveSpellcooldown.Stop();
            _massiveSpellcooldown.Start();
        }
    }
}
