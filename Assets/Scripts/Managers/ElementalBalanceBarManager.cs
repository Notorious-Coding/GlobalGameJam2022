using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementalBalanceBarManager : MonoBehaviour
{
    [SerializeField]
    ElementalBalanceSO _data;

    public GameObject StepPrefab;
    public RectTransform ParentStepsTransform;
    // Start is called before the first frame update
    void Start()
    {
        InstantiateBalanceBarSteps();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void InstantiateBalanceBarSteps()
    {
        foreach (int stepValue in _data.Steps)
        {
            float calculatedXPosition = ((ParentStepsTransform.sizeDelta.x / 2 ) * stepValue) / Mathf.Abs(_data.MaxValue);
            GameObject leftStepInstance = GameObject.Instantiate(StepPrefab, Vector3.zero, Quaternion.identity, ParentStepsTransform);
            leftStepInstance.transform.localEulerAngles = Vector3.zero;
            GameObject rightStepInstance = GameObject.Instantiate(StepPrefab, Vector3.zero, Quaternion.identity, ParentStepsTransform);
            rightStepInstance.transform.localEulerAngles = Vector3.zero;
            leftStepInstance.GetComponent<RectTransform>().localPosition = new Vector3(-calculatedXPosition, 0, 0);
            rightStepInstance.GetComponent<RectTransform>().localPosition = new Vector3(calculatedXPosition, 0, 0);
        }
    }

}
