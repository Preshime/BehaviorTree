using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedController : ActionController
{
    public RedController() : base(0, true)
    {
    }

    public RedController(int rPriority) : base(rPriority, true)
    {
    }

    //public override bool CheckSelf()
    //{
    //    bool b = false;
    //    if (WorldModel.Instance.TryGetValue("Red", out b) && b)
    //    {
    //        return true;
    //    }
    //    return false;
    //}

    //protected override void Action()
    //{
        
    //}

    protected override void ActionEnd()
    {
    }
}
