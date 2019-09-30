using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Go4PlayerController : ActionController
{
    public Go4PlayerController() : base(0, false) { }

    public Go4PlayerController(int rPriority) : base(rPriority, false)
    {
    }

    //public override bool CheckSelf()
    //{
    //    bool b = false;
    //    if (this.Model.TryGetValue("Go4Player", out b) && b && this.Model.CanPlay("Go4Player"))
    //    {
    //        return true;
    //    }
    //    return false;
    //}

    //protected override void Action()
    //{
    //    BehaviorTreeController.Instance.SetAction(TreeID, "Move", new Go4Player() { IsEnd = false, SignName = "Move" });
    //}

    protected override void ActionEnd()
    {
        throw new System.NotImplementedException();
    }
}
