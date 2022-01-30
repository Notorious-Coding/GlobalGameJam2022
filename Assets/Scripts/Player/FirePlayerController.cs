using UnityEngine;
using UnityEngine.InputSystem;

public class FirePlayerController : PlayerController
{
    [SerializeField] Cooldown _massiveSpellcooldown;
    private void Awake()
    {
        SetState(GetState<DefaultState>());
    }

    void FixedUpdate()
    {
        if (!(CurrentState is StunState))
        {
            Move();
            // Pendant la visée de la comet, on ne veux plus tourner le player.
            if (!(CurrentState is FireCometState))
                Turn();
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

        if (CurrentState is FireCometState && CurrentState.IsStateComplete){
            SetState(GetState<DefaultState>());
        }

        CurrentState.HandleLogic();
    }

    public new void OnFireBasicSpell(InputAction.CallbackContext ctx)
    {
        if(!(CurrentState is FireCometState) && !(CurrentState is StunState))
            base.OnFireBasicSpell(ctx);
    }

    public void OnFireMassiveSpell(InputAction.CallbackContext ctx)
    {
        if(!(CurrentState is FireCometState) && !(CurrentState is StunState) && _massiveSpellcooldown.isEnded)
        {
            _massiveSpellcooldown.Stop();
            _massiveSpellcooldown.Start();
            SetState(GetState<FireCometState>());
        }
    }


}
