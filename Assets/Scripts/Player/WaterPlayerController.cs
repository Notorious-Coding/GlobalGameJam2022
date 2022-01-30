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

    public void OnFireMassiveSpell(InputAction.CallbackContext ctx)
    {
        if(!(CurrentState is FireWaterBallSpellState) && _massiveSpellcooldown.isEnded)
        {
            SetState(GetState<FireWaterBallSpellState>());
            _massiveSpellcooldown.Stop();
            _massiveSpellcooldown.Start();
        }
    }
}
