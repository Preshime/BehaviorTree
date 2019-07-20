using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingleNode : ControllerNode
{
    public SingleNode()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        NodeType = NodeType.SingleNode;
    }

    public override void Play(bool IsOverride = false)
    {
        if (Child != null && CheckSelf())
        {
            for (int i = 0; i < Child.Count; i++)
            {
                isPlay = true;
                Child[i].Play();
                return;
            }
        }
    }

    public override void Stop()
    {
        isPlay = false;
        base.Stop();
    }

    public override int IsPlay()
    {
        return isPlay ? 1 : 0;
    }
}
