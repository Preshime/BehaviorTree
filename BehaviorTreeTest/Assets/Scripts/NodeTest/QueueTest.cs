using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueTest : QueueNode
{
    public QueueTest(int Priority = 0)
    {
    }

    public override bool CheckSelf()
    {
        string ss;
        return Model.TryGetValue("queue", out ss) && ss == "111";
    }
}
