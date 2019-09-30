using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveAroundController : ActionController
{
    public MoveAroundController() : base(0, false) { }

    public MoveAroundController(int rPriority) : base(rPriority, false)
    {
    }

    //public override bool CheckSelf()
    //{
    //    bool b = false;
    //    if (this.Model.TryGetValue("MoveAround", out b) && b && this.Model.CanPlay("MoveAround"))
    //    {
    //        return true;
    //    }
    //    return false;

    //}

    //protected override void Action()
    //{
    //    BehaviorTreeController.Instance.SetAction(this.TreeID, "Move", new MoveAround() { IsEnd = false, SignName = "Move" });
    //}

    protected override void ActionEnd()
    {

    }


}