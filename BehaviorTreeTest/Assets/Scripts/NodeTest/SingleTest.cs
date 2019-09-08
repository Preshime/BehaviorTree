using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTest : SingleNode
{
    public SingleTest() : base(0)
    {
    }

    public SingleTest(int Priority = 0) : base(Priority)
    {
    }

    public override bool CheckSelf()
    {
        int i;
        return Model.TryGetValue("single", out i) && i < 5;
    }

}
