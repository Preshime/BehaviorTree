using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallelTest : ParallelNode
{
    public ParallelTest(TreeNode Parent, int Priority) : base(Parent, Priority)
    {
    }

    public override bool CheckSelf()
    {
        string ss;
        return WorldModel.Instance.TryGetValue("Parallel", out ss) && ss == "111";
    }


}
