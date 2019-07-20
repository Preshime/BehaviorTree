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

    public QueueNode(TreeNode Parent) : base(Parent)
    {
    }

    public override int IsPlay()
    {
        return isPlay ? 1 : 0;
    }

    public override void Play(bool IsOverride)
    {
        isPlay = true;
        if (Child != null && CheckSelf())
        {
            nPlayIndex = 0;
            Child[0].Play();
            Action<int> action = t =>
            {
                StartQueue();
            };

            action.BeginInvoke(0, null, null);
        }
    }

    public override void Stop()
    {
        isPlay = false;
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
