using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWallProjectile : Projectile
{
    [SerializeField] int _repulsiveForce;

    private void Start()
    {
        base.Start();
    }
    private void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Rigidbody>().AddForce((-other.transform.forward) * _repulsiveForce, ForceMode.Impulse);
        }
    }
}
