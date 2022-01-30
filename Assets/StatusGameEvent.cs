using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StatusGameEventData
{
    public StatusEnum Status;
    public float Intensity;

    // override object.Equals
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        else
        {
            StatusGameEventData statusGameEventData = (StatusGameEventData)obj;
            return statusGameEventData.Status.Equals(Status) && statusGameEventData.Intensity == Intensity;
        }
    }
}
