using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterState : State
{
    [SerializeField]
    private PlayerController _player;

    private Cooldown _burnRate;
    private StatusSO _statusDatas;
    public override void HandleLogic()
    {
      
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
