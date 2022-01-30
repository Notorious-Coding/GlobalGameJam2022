using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField]
    ChamanDataSO _chamanData;
    [SerializeField]
    ElementalBalanceSO _elementalBalanceData;
    private float _currentIntensity;
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

    private void LifeChange(float newValue)
    {
        //Change health on UI
        HealthBarSlider.value += newValue;
        
    }

    public void UpdateBalanceBarSliderValues(float value)
    {
        ElementalBalanceBarSlider.value += value;
        float absElementalValue = Mathf.Abs(ElementalBalanceBarSlider.value);
        int newIntensity = _elementalBalanceData.Steps.LastOrDefault(val => val <= absElementalValue);
        int intensityIndex = _elementalBalanceData.Steps.IndexOf(newIntensity);
        if (newIntensity != _currentIntensity)
        {
            StatusGameEventData gameEventData = new StatusGameEventData();
            gameEventData.Intensity = value;
            gameEventData.IntensityIndex = intensityIndex;
            if (ElementalBalanceBarSlider.value < 0)
            {
                gameEventData.Status = _elementalBalanceData.SecondStatus;
            }
            if (ElementalBalanceBarSlider.value == 0)
            {
                gameEventData.Status = StatusEnum.EmptyStatus;
            }
            if (ElementalBalanceBarSlider.value > 0)
            {
                gameEventData.Status = _elementalBalanceData.FirstStatus;
            }
            _elementalBalanceData.NotifyStatusChange(gameEventData);
        }
    }
}
