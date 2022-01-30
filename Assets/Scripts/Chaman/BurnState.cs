using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnState : State
{
   
    [SerializeField]
    private ChamanDataSO _chamanData;

    private Cooldown _burnRate;
    private StatusSO _statusDatas;
    private int _intensityIndex;


    public void SetStateDatas(StatusSO statusDatas, int intensityIndex)
    {
        _intensityIndex = intensityIndex;
        _statusDatas = statusDatas;
        _burnRate = new Cooldown(_statusDatas.timeBetweenStatusApliance);
    }
    public override void HandleLogic()
    {
        if(_statusDatas != null && _burnRate != null)
        {
            if (_burnRate.isEnded && !IsStateComplete)
            {
                _chamanData.UpdateLife(-(_statusDatas.damages + (_statusDatas.statusIntensityIncrementValue * _intensityIndex)));
                _burnRate.Stop();
                _burnRate.Start();
            }
        }

    }

    public override void HandlePhysicsLogic()
    {
        return;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
