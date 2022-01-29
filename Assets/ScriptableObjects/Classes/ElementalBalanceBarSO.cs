using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnElementalBalanceValueChangeDelegate(int amount);

[CreateAssetMenu(menuName = "ElementBalanceBarData")]
public class ElementalBalanceBarSO : ScriptableObject
{
    [Header("Information de la bar d'élément")]
    public int ElementalBalanceValue;
    public int MinValue;
    public int MaxValue;

    public event OnElementalBalanceValueChangeDelegate OnElementalBalanceValueChangeEvent;
    public void UpdateElementalBalanceValue(int amount)
    {
        ElementalBalanceValue += amount;
        if(amount < MinValue)
        {
            amount = MinValue;
        }

        if(amount > MaxValue)
        {
            amount = MaxValue;
        }
        OnElementalBalanceValueChangeEvent(amount);
    }

    public void SubscribeToElementalBalanceValue(OnElementalBalanceValueChangeDelegate elementalBalanceValueChangeDelegate)
    {
        OnElementalBalanceValueChangeEvent += elementalBalanceValueChangeDelegate;
    }

    public void UnsubscribeToElementalBalanceValue(OnElementalBalanceValueChangeDelegate elementalBalanceValueChangeDelegate)
    {
        OnElementalBalanceValueChangeEvent -= elementalBalanceValueChangeDelegate;
    }
}
