using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedController : ActionController
{
    public RedController() : base(0, "Red",true)
    {
    }

    public RedController(int rPriority) : base(rPriority, "Red", true)
    {
    }

    public override bool CheckSelf()
    {
        bool b = false;
        if (WorldModel.Instance.TryGetValue("Red", out b) && b)
        {
            return true;
        }
        return false;
    }

    protected override void Action()
    {
        BehaviorTreeController.Instance.SetAction(TreeID, "Color", new Red() { IsEnd = false, SignName = "Color" });
    }

    protected override void ActionEnd()
    {
    }
}
