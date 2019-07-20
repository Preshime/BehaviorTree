using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTest : SingleNode
{
    public SingleTest(int Priority = 0)
    {
    }

    public override bool CheckSelf()
    {
        int i;
        return Model.TryGetValue("single", out i) && i < 5;
    }

}
