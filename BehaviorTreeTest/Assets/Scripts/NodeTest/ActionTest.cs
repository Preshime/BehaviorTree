using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class ActionTest : ActionController
{
    public ActionTest(int Priority = 0) : base(Priority, false)
    {
    }

    //public override bool CheckSelf()
    //{
    //    bool b = false;
    //    if (Model.TryGetValue("action", out b) && b)
    //    {
    //        Model.SetTagIsPlayed("action");
    //        return true;
    //    }
    //    return false;
    //}

    //protected override void Action()
    //{
    //    Debug.Log($"{Name}:action Start");
    //}

    protected override void ActionEnd()
    {
        Debug.Log($"{Name}:action end");
    }


    private void Act(bool b)
    {
        while (b)
        {
            Debug.Log($"{Name}:action");
        }
    }

}
