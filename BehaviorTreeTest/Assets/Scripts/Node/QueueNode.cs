using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public abstract class QueueNode : ControllerNode
{
    private int nPlayIndex;

    private int PlayIndex
    {
        get { return nPlayIndex; }
        set
        {
            nPlayIndex = value;
            if (value != 0)
                IndexChange();
        }
    }



    protected float CheckTime = 0.5f;

    public QueueNode(int Priority) { NodeType = NodeType.QueueNode; this.Priority = Priority; }

    public override int IsPlay()
    {
        return mIsPlay ? 1 : 0;
    }

    public override bool Play(bool IsOverride)
    {
        if (Child != null && CheckSelf())
        {
            mIsPlay = true;
            nPlayIndex = 0;
            Child[0].Play();
            Action<int> action = t =>
            {
                StartQueue();
            };

            action.BeginInvoke(0, null, null);
            return true;
        }
        return false;
    }

    public override void Stop()
    {
        mIsPlay = false;
        if (Child != null && nPlayIndex < Child.Count)
        {
            Child[nPlayIndex].Stop();
            nPlayIndex = 0;
        }
    }

    public override void Init()
    {
        base.Init();
        NodeType = NodeType.QueueNode;
    }

    public override void OnDestory()
    {
        for (int i = 0; i < Child.Count; i++)
            Child[i].OnDestory();
        base.OnDestory();
    }

    private void StartQueue()
    {
        while (mIsPlay)
        {
            new WaitForSeconds(CheckTime);
            if (Child[PlayIndex].IsPlay() == 0)
                PlayIndex += 1;
        }
    }

    private void IndexChange()
    {

    }

}
