using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ParallelNode : ControllerNode
{
    private int nPlayNum;

    public ParallelNode(TreeNode Parent) : base(Parent)
    {
    }

    public override int IsPlay()
    {
        return nPlayNum;
    }

    public override void Play(bool IsOverride = false)
    {
        if (Child != null && CheckSelf())
        {
            for (int i = 0; i < Child.Count; i++)
            {
                isPlay = true;
                Child[i].Play();
            }
        }
    }

    public override void Stop()
    {
        base.Stop();
        nPlayNum = 0;
        isPlay = false;
    }
}
