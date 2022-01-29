using UnityEngine;

public class Chaman : MonoBehaviour
{
    [SerializeField]
    ChamanDataSO _data;

    // Start is called before the first frame update
    void Start()
    {
    }


    public void TakeDamage(int damage) 
    {
        _data.UpdateLife(-damage);
    }
}
