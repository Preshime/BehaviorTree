using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingleNode : ControllerNode
{
    public SingleNode(int Priority) { NodeType = NodeType.SingleNode; this.Priority = Priority; }

    public override void Init()
    {
        base.Init();
        NodeType = NodeType.SingleNode;
    }

    public override bool Play(bool IsOverride = false)
    {
        if (Child != null && CheckSelf())
        {
            for (int i = 0; i < Child.Count; i++)
            {
                mIsPlay = true;
                if (Child[i].Play())
                    return true;
            }
        }
        return false;
    }

    public override void Stop()
    {
        mIsPlay = false;
        base.Stop();
    }

    public override int IsPlay()
    {
        return mIsPlay ? 1 : 0;
    }
}
