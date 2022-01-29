using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public struct StatusGameEventData
{
    public StatusEnum status;
    public int intensity;

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
            return statusGameEventData.status.Equals(this.status) && statusGameEventData.intensity == intensity;
        }
    }
}
