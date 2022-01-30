using UnityEngine;

public class Chaman : Entity
{
    [SerializeField]
    ChamanDataSO _data;

    // Start is called before the first frame update
    void Start()
    {
    }

    public override void TakeDamage(int damage)
    {
        _data.UpdateLife(-damage);
    }
}
