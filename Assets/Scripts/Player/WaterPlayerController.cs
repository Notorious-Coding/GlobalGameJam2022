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
        // Pendant la visée de la comet, on ne veux plus tourner le player.
        if(!(CurrentState is FireCometState))
            Turn();

        CurrentState.HandlePhysicsLogic();
    }


    private void Update()
    {
        Debug.Log(CurrentState);
        if (CurrentState is BasicSpellState && CurrentState.IsStateComplete)
        {
            SetState(GetState<DefaultState>());
        }

        if (CurrentState is FireCometState && CurrentState.IsStateComplete){
            SetState(GetState<DefaultState>());
        }

        CurrentState.HandleLogic();
    }

    public void OnFireBasicSpell(InputAction.CallbackContext ctx)
    {
        if(!(CurrentState is FireCometState))
            base.OnFireBasicSpell(ctx);
    }

    public void OnFireMassiveSpell(InputAction.CallbackContext ctx)
    {
        if(!(CurrentState is FireCometState) && _massiveSpellcooldown.isEnded)
        {
            _massiveSpellcooldown.Stop();
            _massiveSpellcooldown.Start();
            SetState(GetState<FireCometState>());
        }
    }


}
