using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public delegate void OnElementalBalanceValueChangeDelegate(float amount);
public delegate void OnElementalBalanceStatusGameEventDataDelegate(StatusGameEventData newStatus);
public delegate void OnElementBalanceCurrentStatusIntenistyChangeDelegate(float newIntensity);

[CreateAssetMenu(menuName = "ElementBalanceBarData")]
public class ElementalBalanceSO : ScriptableObject
{
    [Header("Information de la bar d'élément")]
    public float ElementalBalanceValue;

    [Range(min: -5000, max: -10)]
    public float MinValue;
    [Range(min: 10, max: 5000)]
    public float MaxValue;
    public List<int> Steps;

    public StatusEnum FirstStatus;
    public StatusEnum SecondStatus;
    private StatusGameEventData _statusGameEventData;

    public event OnElementalBalanceValueChangeDelegate OnElementalBalanceValueChangeEvent;
    public event OnElementalBalanceStatusGameEventDataDelegate OnElementalBalanceStatusGameEventDataEvent;
    public void UpdateElementalBalanceValue(int amount)
    {
        StatusGameEventData oldStatusValue = _statusGameEventData;
        ElementalBalanceValue += amount;
        ManageElementalBalanceValueChange();
        CheckCurrentStatus();
        CheckCurrentIntensity();
        if (!_statusGameEventData.Equals(oldStatusValue))
        {
            OnElementalBalanceStatusGameEventDataEvent(_statusGameEventData);
        }
        OnElementalBalanceValueChangeEvent(ElementalBalanceValue);
    }

    private void CheckCurrentIntensity()
    {
        float absElementalValue = Mathf.Abs(ElementalBalanceValue);
        _statusGameEventData.intensity =  Steps.LastOrDefault(val => absElementalValue >= val);

    }

    private void CheckCurrentStatus()
    {
        if (ElementalBalanceValue < 0)
        {
            _statusGameEventData.status = FirstStatus;
        }
        if (ElementalBalanceValue == 0)
        {
            _statusGameEventData.status = StatusEnum.EmptyStatus;
        }
        if (ElementalBalanceValue > 0)
        {
            _statusGameEventData.status = SecondStatus;
        }
    }

    private void ManageElementalBalanceValueChange()
    {
        if (ElementalBalanceValue < MinValue)
        {
            ElementalBalanceValue = MinValue;
        }

        if (ElementalBalanceValue > MaxValue)
        {
            ElementalBalanceValue = MaxValue;
        }
    }

    public void SubscribeToElementalBalanceValue(OnElementalBalanceValueChangeDelegate elementalBalanceValueChangeDelegate)
    {
        OnElementalBalanceValueChangeEvent += elementalBalanceValueChangeDelegate;
    }

    public void UnsubscribeToElementalBalanceValue(OnElementalBalanceValueChangeDelegate elementalBalanceValueChangeDelegate)
    {
        OnElementalBalanceValueChangeEvent -= elementalBalanceValueChangeDelegate;
    }

    public void SubscribeToElementalBalanceStatus(OnElementalBalanceStatusGameEventDataDelegate elementalBalanceStatusChangeDelegate)
    {
        OnElementalBalanceStatusGameEventDataEvent += elementalBalanceStatusChangeDelegate;
    }

    public void UnsubscribeToElementalBalanceStatus(OnElementalBalanceStatusGameEventDataDelegate elementalBalanceStatusChangeDelegate)
    {
        OnElementalBalanceStatusGameEventDataEvent -= elementalBalanceStatusChangeDelegate;
    }


    void OnValidate()
    {
        MinValue = Mathf.Round(MinValue / 10f) * 10f;
        MaxValue = Mathf.Round(MaxValue / 10f) * 10f;
    }
}
