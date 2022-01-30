using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Chaman : Entity
{
    [SerializeField]
    ChamanDataSO _data;
    [SerializeField]
    ElementalBalanceSO _elemntalBarData;
    private StatusEnum _currentStatus;

    [SerializeField]
    public List<StatusSO> possibleStatus;
    private StatusSO _currentStatusDatas;
    // Start is called before the first frame update
    void Start()
    {
        SetState(GetState<DefaultState>());
        _elemntalBarData.SubscribeToElementalBalanceStatusChange(ManageStatusChange);
    }

    private void Update()
    {
        CurrentState.HandleLogic();
    }

    private void FixedUpdate()
    {
        CurrentState.HandlePhysicsLogic();

    }
    private void ManageStatusChange(StatusGameEventData eventData)
    {
        _currentStatus = eventData.Status;
        StatusSO currentStatus = possibleStatus.FirstOrDefault(status => status.statusBound.Equals(eventData.Status));
        switch (_currentStatus)
        {
            case StatusEnum.Fire:
                SetState(GetState<BurnState>());
                GetState<BurnState>().SetStateDatas(currentStatus, eventData.IntensityIndex);
                break;
            default:
                SetState(GetState<DefaultState>());
                break;
        }
    }


    public override void TakeDamage(float damage)
    {
        _data.UpdateLife(-damage);
    }
}
