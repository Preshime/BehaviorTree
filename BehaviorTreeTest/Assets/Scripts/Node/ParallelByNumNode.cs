﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ParallelByNumNode : ControllerNode
{
    public int ParallelNum;

    //private ParallelByNumNode()
    //{
    //    NodeType = NodeType.ParallelByNumNode;
    //}

    public ParallelByNumNode(TreeNode Parent, int Num, int Priority)
    {
        ParallelNum = Num;
        NodeType = NodeType.ParallelByNumNode;
        this.Priority = Priority;
    }

    public override int IsPlay()
    {
        throw new System.NotImplementedException();
    }

    public override bool Play(bool IsOverride = false)
    {
        if (Child != null && CheckSelf())
        {
            int nPlayNum = 0;
            for (int i = 0; i < Child.Count; i++)
            {
                if (Child[i].CheckSelf())
                {
                    if (!mIsPlay) mIsPlay = true;
                    Child[i].Play();
                    if (++nPlayNum >= ParallelNum)
                        break;
                }
            }
            return nPlayNum > 0;
        }
        return false;
    }

    public override void Stop()
    {
        base.Stop();
        mIsPlay = false;
    }
}
