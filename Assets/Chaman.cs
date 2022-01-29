using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaman : MonoBehaviour
{
    [SerializeField]
    ChamanDataSO _data;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TakeDamage(10);
    }

    public void TakeDamage(int damage)
    {
        _data.UpdateLife(-damage);
    }
}
