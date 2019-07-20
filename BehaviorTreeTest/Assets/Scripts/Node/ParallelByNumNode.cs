using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ParallelByNumNode : ControllerNode
{
    public int ParallelNum;

    private ParallelByNumNode()
    {
        NodeType = NodeType.ParallelByNumNode;
    }

    public ParallelByNumNode(TreeNode Parent, int Num, int Priority = 0)
    {
        ParallelNum = Num;
        NodeType = NodeType.ParallelByNumNode;
    }

    public override int IsPlay()
    {
        throw new System.NotImplementedException();
    }

    public override void Play(bool IsOverride = false)
    {
        if (Child != null && CheckSelf())
        {
            int nPlayNum = 0;
            for (int i = 0; i < Child.Count; i++)
            {
                if (Child[i].CheckSelf())
                {
                    if (!isPlay) isPlay = true;
                    Child[i].Play();
                    if (++nPlayNum >= ParallelNum)
                        return;
                }
            }
        }
    }

    public override void Stop()
    {
        base.Stop();
        isPlay = false;
    }
}
