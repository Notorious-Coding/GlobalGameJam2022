using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public abstract class Entity : StateMachine, IDamagable
{
    public abstract void TakeDamage(float damage);
}

