using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnLifeChangeDelegate(float damageTaken);

[CreateAssetMenu(menuName = "ChamanData")]
public class ChamanDataSO : ScriptableObject
{
    [Header("Informations du joueur")]
    public int Life;

    public event OnLifeChangeDelegate OnLifeChangeEvent;

    public void UpdateLife(float value)
    {
        OnLifeChangeEvent?.Invoke(value);
    }
    

    public void Subscribe(OnLifeChangeDelegate takeDamageDelegate)
    {
        OnLifeChangeEvent += takeDamageDelegate;
    }

    public void Unsubscribe(OnLifeChangeDelegate takeDamageDelegate)
    {
        OnLifeChangeEvent -= takeDamageDelegate;
    }
}
