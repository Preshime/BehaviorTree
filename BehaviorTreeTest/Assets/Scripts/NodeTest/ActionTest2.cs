using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTest2 : ActionController
{
    public ActionTest2(int Priority = 0) : base(Priority, "action2")
    {
    }

    public override bool CheckSelf()
    {
        bool b;
        string s;
        if ((Model.TryGetValue("action2", out b) && b))
        {
            //Model.SetTagIsPlayed("action2");
            //Model.SetTagIsPlayed("111");
            return true;
        }
        return false;
    }

    protected override void Action()
    {
        Debug.Log($"{Name}:action Start");
        Action<int> action = i =>
         {
             Act(i);
         };
        action.BeginInvoke(0, null, null);
    }

    protected override void ActionEnd()
    {
        Debug.Log($"{Name}:action end");
    }


    private void Act(int i)
    {
        while (i < 5)
        {
            Debug.Log($"{Name}:action,i:{i}");
            i++;
        }
        this.Stop();
    }
}
