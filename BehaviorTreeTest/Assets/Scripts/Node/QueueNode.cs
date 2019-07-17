using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public abstract class QueueNode : ControllerNode
{
    private int iPlayIndex;

    private int PlayIndex
    {
        get { return iPlayIndex; }
        set
        {
            iPlayIndex = value;
            if (value != 0)
                IndexChange();
        }
    }

    public QueueNode()
    {
        Init();
    }

    protected abstract override bool CheckSelf();

    protected float CheckTime = 0.5f;

    public override int IsPlay()
    {
        return isPlay ? 1 : 0;
    }

    protected override void FindChild()
    {
    }

    public override void Play(bool IsOverride)
    {
        isPlay = true;
        if (Child != null && CheckSelf())
        {
            iPlayIndex = 0;
            Child[0].Play();
            Action<int> action = t =>
            {
                StartQuequ();
            };

            action.BeginInvoke(0, null, null);
        }
    }

    public override void Stop()
    {
        isPlay = false;
        if (Child != null && iPlayIndex < Child.Count)
        {
            Child[iPlayIndex].Stop();
            iPlayIndex = 0;
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

    private void StartQuequ()
    {
        while (isPlay)
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
