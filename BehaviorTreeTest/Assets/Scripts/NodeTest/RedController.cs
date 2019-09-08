using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : ActionController
{
    public Red(int rPriority) : base(rPriority, "Red")
    {
    }

    public override bool CheckSelf()
    {
        bool b = false;
        if (Model.TryGetValue("Red", out b) && b)
        {
            return true;
        }
        return false;
    }

    protected override void Action()
    {
        throw new System.NotImplementedException();
    }

    protected override void ActionEnd()
    {
        throw new System.NotImplementedException();
    }
}
