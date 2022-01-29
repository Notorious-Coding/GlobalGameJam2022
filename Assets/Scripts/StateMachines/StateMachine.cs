using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    [SerializeField] private List<State> _states;

    /// <summary>
    /// Etat courant de la SM.
    /// </summary>
    protected State CurrentState;

    protected List<State> States => _states;

    /// <summary>
    /// Permet de changer l'état courant et de jouer les méthodes OnStateExit et OnStateEnter.
    /// </summary>
    /// <param name="state"></param>
    protected void SetState(State state)
    {
        if (CurrentState != null)
            CurrentState.OnStateExit();
        CurrentState = state;
        CurrentState.OnStateEnter();
    }

    protected T GetState<T>() where T : State
    {
        return _states.OfType<T>().FirstOrDefault();
    }
}

