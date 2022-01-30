using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public delegate void AdjustElementalBalanceValueChangeDelegate(float amount);
public delegate void OnElementalBalanceStatusChangeDelegate(StatusGameEventData newStatus);
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
    [SerializeField]
    public List<int> Steps;

    public StatusEnum FirstStatus;
    public StatusEnum SecondStatus;
    private StatusGameEventData _statusGameEventData;

    public event AdjustElementalBalanceValueChangeDelegate AdjustBalanceValueChangeEvent;
    public event OnElementalBalanceStatusChangeDelegate OnElementalBalanceStatusChangeEvent;

    public void OnSpellLaunch(SpellSO spell)
    {
        if (spell.Status.Equals(FirstStatus))
        {
            AdjustBalanceValueChangeEvent?.Invoke(spell.AmountOfMalus);
        }

        if (spell.Status.Equals(SecondStatus))
        {
            AdjustBalanceValueChangeEvent?.Invoke(-spell.AmountOfMalus);
        }
    }

    public void NotifyStatusChange(StatusGameEventData eventData)
    {
        OnElementalBalanceStatusChangeEvent?.Invoke(eventData);
    }


    //private void CheckCurrentStatus()
    //{
    //    if (ElementalBalanceValue < 0)
    //    {
    //        _statusGameEventData.status = FirstStatus;
    //    }
    //    if (ElementalBalanceValue == 0)
    //    {
    //        _statusGameEventData.status = StatusEnum.EmptyStatus;
    //    }
    //    if (ElementalBalanceValue > 0)
    //    {
    //        _statusGameEventData.status = SecondStatus;
    //    }
    //}

    public void SubscribeToElementalBalanceValue(AdjustElementalBalanceValueChangeDelegate elementalBalanceValueChangeDelegate)
    {
        AdjustBalanceValueChangeEvent += elementalBalanceValueChangeDelegate;
    }

    public void UnsubscribeToElementalBalanceValue(AdjustElementalBalanceValueChangeDelegate elementalBalanceValueChangeDelegate)
    {
        AdjustBalanceValueChangeEvent -= elementalBalanceValueChangeDelegate;
    }

    public void SubscribeToElementalBalanceStatusChange(OnElementalBalanceStatusChangeDelegate elementalBalanceStatusChangeDelegate)
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
    }
}
