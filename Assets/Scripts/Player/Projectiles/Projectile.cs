using UnityEditor;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private int _damage;
    private void FixedUpdate()
    {
        this.transform.Translate(transform.forward * _speed * Time.fixedDeltaTime, Space.World);       
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            var enemy = collision.transform.GetComponent<Enemy>();
            enemy.TakeDamage(_damage);
        }
    }
}
