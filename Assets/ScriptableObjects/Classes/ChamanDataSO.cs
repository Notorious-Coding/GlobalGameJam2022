using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnLifeChangeDelegate(int damageTaken);

[CreateAssetMenu(menuName = "ChamanData")]
public class ChamanDataSO : ScriptableObject
{
    [Header("Informations du joueur")]
    public int Life;

    public event OnLifeChangeDelegate OnLifeChangeEvent;

    public void UpdateLife(int value)
    {
        Life += value;
        OnLifeChangeEvent(Life);
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
