using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField]
    ChamanDataSO _data;
    // Start is called before the first frame update
    void Start()
    {
        _data.Subscribe(TakeDamage);
    }

    private void TakeDamage(int damage)
    {
        //Change health on UI
        Debug.Log("Je prend des damage dans l'hud");
    }
}
