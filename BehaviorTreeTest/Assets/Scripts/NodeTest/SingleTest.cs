using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTest : SingleNode
{
    public SingleTest(ControllerNode Parent) : base(Parent)
    {
    }

    public override bool CheckSelf()
    {
        int i;
        if (Model.TryGetValue<int>("123", out i))
        {
            return i < 5;
        }
        return false;
    }

}
