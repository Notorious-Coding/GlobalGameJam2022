using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Etat d'une state machine.
/// </summary>
public abstract class State : MonoBehaviour
{

    /// <summary>
    /// Cet �tat est-il termin�?
    /// </summary>
    public bool IsStateComplete { get; set; }

    /// <summary>
    /// Permet d'�xecuter la logique de la m�thode Update().
    /// </summary>
    public abstract void HandleLogic();

    /// <summary>
    /// Permet d'�x�cuter la logique de la m�thode FixedUpdate().
    /// </summary>
    public abstract void HandlePhysicsLogic();

    /// <summary>
    /// M�thode permettant d'�x�cuter de la logique a l'entr�e de l'�tat. 
    /// </summary>
    public virtual void OnStateEnter()
    {
        IsStateComplete = false;
        return;
    }

    /// <summary>
    /// M�thode permettant d'�x�cuter de la logique a la sortie de l'�tat. 
    /// </summa'ry>
    public virtual void OnStateExit()
    {
        return;
    }

    public virtual void Interrupt()
    {

    }
    public virtual bool CanBeUsed()
    {
        return true;
    }

    public virtual void TriggerExit(Collider other)
    {
        return;
    }

    public virtual void TriggerEnter(Collider other)
    {
        return;
    }

    public virtual void TriggerStay(Collider other)
    {
        return;
    }

    public virtual void CollisionEnter(Collision collision)
    {
        return;
    }

    public virtual void CollisionExit(Collision collision)
    {
        return;
    }

    public virtual void CollisionStay(Collision collision)
    {
        return;
    }
}

