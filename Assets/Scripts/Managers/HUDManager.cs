using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField]
    ChamanDataSO _chamanData;
    [SerializeField]
    ElementalBalanceSO _elementalBalanceData;
    public Slider ElementalBalanceBarSlider;
    public Slider HealthBarSlider;
    // Start is called before the first frame update
    void Start()
    {
        HealthBarSlider.maxValue = _chamanData.Life;
        HealthBarSlider.value = _chamanData.Life;
        _chamanData.Subscribe(LifeChange);
        _elementalBalanceData.SubscribeToElementalBalanceValue(UpdateBalanceBarSliderValues);
    }

    private void LifeChange(int newValue)
    {
        //Change health on UI
        HealthBarSlider.value = newValue;
    }

    private void UpdateBalanceBarSliderValues(float value)
    {
        ElementalBalanceBarSlider.value = value;
    }
}
