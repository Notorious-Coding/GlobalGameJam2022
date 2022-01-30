using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ElementalPlayer")]
public class ElementalPlayerSO : ScriptableObject
{
    public float MoveSpeed;
    public Cooldown AttackRate;
    public SpellSO BasicSpellData;
    public SpellSO MassiveSpellData;
}