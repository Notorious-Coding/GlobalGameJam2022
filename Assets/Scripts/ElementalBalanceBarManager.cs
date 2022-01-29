using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementalBalanceBarManager : MonoBehaviour
{
    [SerializeField]
    ElementalBalanceSO _data;

    public Slider ElementalBalanceBarSlider;
    // Start is called before the first frame update
    void Start()
    {
        ElementalBalanceBarSlider.minValue = _data.MinValue;
        ElementalBalanceBarSlider.maxValue = _data.MaxValue;
        _data.SubscribeToElementalBalanceValue(updateSliderValues);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void updateSliderValues(float value)
    {
        ElementalBalanceBarSlider.value = value;
    }

}
