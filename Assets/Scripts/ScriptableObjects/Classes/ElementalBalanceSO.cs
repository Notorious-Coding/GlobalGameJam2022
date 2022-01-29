using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnElementalBalanceValueChangeDelegate(float amount);
public delegate void OnElementalBalanceStatusChangeDelegate(StatusEnum newStatus);

[CreateAssetMenu(menuName = "ElementBalanceBarData")]
public class ElementalBalanceSO : ScriptableObject
{
    [Header("Information de la bar d'élément")]
    public float ElementalBalanceValue;

    [Range(min: -5000, max: -10)]
    public float MinValue;
    [Range(min: 10, max: 5000)]
    public float MaxValue;
    [Range(min: 5, max: 2500)]
    public float StepSize;

    public StatusEnum FirstStatus;
    public StatusEnum SecondStatus;

    public StatusEnum CurrentStatus;

    public event OnElementalBalanceValueChangeDelegate OnElementalBalanceValueChangeEvent;
    public event OnElementalBalanceStatusChangeDelegate OnElementalBalanceStatusChangeEvent;
    public void UpdateElementalBalanceValue(int amount)
    {
        StatusEnum oldValue = CurrentStatus;
        ElementalBalanceValue += amount;
        if (amount < MinValue)
        {
            ElementalBalanceValue = MinValue;
        }

        if (amount > MaxValue)
        {
            ElementalBalanceValue = MaxValue;
        }

        if(ElementalBalanceValue < 0)
        {
            CurrentStatus = FirstStatus;
        }
        if(ElementalBalanceValue == 0)
        {
            CurrentStatus = StatusEnum.EmptyStatus;
        }
        if(ElementalBalanceValue > 0)
        {
            CurrentStatus = SecondStatus;
        }
        if (!CurrentStatus.Equals(oldValue))
        {
            OnElementalBalanceStatusChangeEvent(CurrentStatus);
        }
        OnElementalBalanceValueChangeEvent(ElementalBalanceValue);
    }

    public void SubscribeToElementalBalanceValue(OnElementalBalanceValueChangeDelegate elementalBalanceValueChangeDelegate)
    {
        OnElementalBalanceValueChangeEvent += elementalBalanceValueChangeDelegate;
    }

    public void UnsubscribeToElementalBalanceValue(OnElementalBalanceValueChangeDelegate elementalBalanceValueChangeDelegate)
    {
        OnElementalBalanceValueChangeEvent -= elementalBalanceValueChangeDelegate;
    }

    public void SubscribeToElementalBalanceStatus(OnElementalBalanceStatusChangeDelegate elementalBalanceStatusChangeDelegate)
    {
        OnElementalBalanceStatusChangeEvent += elementalBalanceStatusChangeDelegate;
    }

    public void UnsubscribeToElementalBalanceStatus(OnElementalBalanceStatusChangeDelegate elementalBalanceStatusChangeDelegate)
    {
        OnElementalBalanceStatusChangeEvent -= elementalBalanceStatusChangeDelegate;
    }

    void OnValidate()
    {
        MinValue = Mathf.Round(MinValue / 10f) * 10f;
        MaxValue = Mathf.Round(MaxValue / 10f) * 10f;
        StepSize = Mathf.Round(StepSize / 5f) * 5f;
        if (StepSize > MaxValue / 2)
        {
            StepSize = MaxValue / 2;
        }

        if (StepSize < MinValue)
        {
            StepSize = MinValue / 2;
        }
    }
}
