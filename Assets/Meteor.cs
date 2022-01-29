using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private int _damage;

    // Start is called before the first frame update
    void Start()
    {
        InflictZoneDamage();
    }

    public void InflictZoneDamage()
    {
        var colliders = Physics.OverlapSphere(this.transform.position, _radius);
        var enemies = colliders.Where((c) => c.CompareTag("Enemy"));
        Debug.Log(enemies.Count());
        foreach(var enemy in enemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(_damage);
        }
    }
}
