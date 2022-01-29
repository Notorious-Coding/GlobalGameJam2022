using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    [SerializeField]
    private ElementalBalanceSO _data;
    // Start is called before the first frame update
    void Start()
    {
        _data.SubscribeToElementalBalanceStatus(ManageStatus);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ManageStatus(StatusGameEventData newStatusInfos)
    {
        switch (newStatusInfos.status)
        {
            case StatusEnum.EmptyStatus:
                Debug.Log("EmptyStatus");
                break;
            case StatusEnum.Fire:
                Debug.Log("New status " + newStatusInfos.status.ToString() + " with intenisty: " + newStatusInfos.intensity);
                break;
            case StatusEnum.Water:
                Debug.Log("New status " + newStatusInfos.status.ToString() + " with intenisty: " + newStatusInfos.intensity);
                break;
            default:
                break;
        }
    }
}
