using UnityEditor;
using UnityEngine;


public abstract class Spell : MonoBehaviour
{
    [SerializeField]
    public GameObject ProjectilePrefab;
    [SerializeField]
    public SpellSO SpellData;
    public abstract void Fire();
}
