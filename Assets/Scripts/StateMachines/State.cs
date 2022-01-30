using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Etat d'une state machine.
/// </summary>
public abstract class State : MonoBehaviour
{

    /// <summary>
    /// Cet état est-il terminé?
    /// </summary>
    public bool IsStateComplete { get; set; }

    /// <summary>
    /// Permet d'éxecuter la logique de la méthode Update().
    /// </summary>
    public abstract void HandleLogic();

    /// <summary>
    /// Permet d'éxécuter la logique de la méthode FixedUpdate().
    /// </summary>
    public abstract void HandlePhysicsLogic();

    /// <summary>
    /// Méthode permettant d'éxécuter de la logique a l'entrée de l'état. 
    /// </summary>
    public virtual void OnStateEnter()
    {
        IsStateComplete = false;
        return;
    }

    /// <summary>
    /// Méthode permettant d'éxécuter de la logique a la sortie de l'état. 
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

