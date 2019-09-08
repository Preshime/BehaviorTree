using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAroundController : ActionController
{
    public MoveAroundController(int rPriority) : base(rPriority, "MoveAround")
    {
    }

    public override bool CheckSelf()
    {
        bool b = false;
        if (WorldModel.Instance.TryGetValue("MoveAround", out b) && b)
        {
            return true;
        }
        return false;

    }

    protected override void Action()
    {
        BehaviorTreeController.Instance.SetAction(this.TreeID, "Move", new MoveAround());
    }

    protected override void ActionEnd()
    {

    }

}
