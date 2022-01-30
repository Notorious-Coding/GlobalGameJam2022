using UnityEditor;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private int _damage;
    [SerializeField] private float _projectileLifeTime;
    [SerializeField] private bool _destroyOnHit;
    protected void Start()
    {
        Destroy(this.gameObject, _projectileLifeTime);
    }
    protected void FixedUpdate()
    {
        this.transform.Translate(transform.forward * _speed * Time.fixedDeltaTime, Space.World);       
    }

    protected void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            var enemy = collision.transform.GetComponent<Enemy>();
            enemy.TakeDamage(_damage);
            if(_destroyOnHit)
                Destroy(this.gameObject);
        }
    }
}
