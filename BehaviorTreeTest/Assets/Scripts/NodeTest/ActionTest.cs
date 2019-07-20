using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class ActionTest : ActionController
{
    public ActionTest(int Priority = 0) : base(Priority)
    {
    }

    public override bool CheckSelf()
    {
        bool b;
        return Model.TryGetValue("action", out b) && b;
    }

    protected override void Action()
    {
        Debug.Log($"{Name}:action Start");
        //Action<bool> action = b =>
        // {
        //     Act(b);
        // };
        //action.BeginInvoke(true, null, null);
    }

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
