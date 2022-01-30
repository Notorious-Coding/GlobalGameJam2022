using UnityEditor;
using UnityEngine;

public class ProjectileSpell : Spell
{
    [Header("Attaques simple")]
    [SerializeField] Transform _firePoint;
    public override void Fire()
    {
        var projectile = Instantiate(ProjectilePrefab, _firePoint.position, _firePoint.rotation);
    }
}
