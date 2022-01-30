

using UnityEngine;

[CreateAssetMenu(menuName = "Status")]
public class StatusSO: ScriptableObject
{
    public StatusEnum statusBound;
    public float damages;
    public float statusIntensityIncrementValue;
    public float timeBetweenStatusApliance;
}
