using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

//父类
public abstract class TreeNode
{
    public TreeNode() { }

    public int ID;

    private int nTreeID;
    public int TreeID
    {
        get
        {
            if (this.Parent == null)
                return nTreeID;
            else
                return Parent.TreeID;
        }
        set { nTreeID = value; }
    }

    public string Name;

    public NodeType NodeType;

    public int Priority;

    private NodeModel rModel;
    public NodeModel Model
    {
        get
        {
            if (Parent == null)
                return rModel;
            else
                return Parent.Model;
        }
        set
        {
            if (Parent == null)
                rModel = value;
        }
    }

    protected bool mIsPlay;

    public TreeNode Parent;
    protected List<TreeNode> Child;

    public abstract void Init();
    public abstract void OnDestory();
    public abstract int IsPlay();
    public abstract bool Play(bool IsOverride = false);
    public abstract void Stop();

    public Check Check;
    public bool CheckSelf()
    {
        return Check?.CheckSelf() ?? false;
    }
    public abstract bool AddNode(TreeNode rNode);
}

//待扩展
public enum NodeType
{
    Base,
    ActionNode,
    SingleNode,
    QueueNode,
    ParallelNode,
    ParallelByNumNode,
}

/// <summary>
/// 控制节点父类
/// </summary>
public abstract class ControllerNode : TreeNode
{


    public abstract override int IsPlay();

    public override void Init()
    {
        Child = new List<TreeNode>();
    }

    public override void OnDestory()
    {
        Child.Clear();
    }

    public override bool AddNode(TreeNode rNode)
    {
        try
        {
            rNode.Parent = this;
            if (Child == null) Child = new List<TreeNode>();
            if (Child.Count == 0)
                Child.Add(rNode);
            else
            {
                bool isAdd = false;
                for (int i = 0; i < Child.Count; i++)
                {
                    if (Child[i].Priority < rNode.Priority)
                    {
                        isAdd = true;
                        Debug.Log("index:" + i);
                        Child.Insert(i, rNode);
                        break;
                    }
                }
                if (!isAdd)
                    Child.Add(rNode);
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"增加节点失败:{e}");
        }
        return true;
    }

    public bool RemoveNode(TreeNode rNode)
    {
        try
        {
            return Child.Remove(rNode);
        }
        catch (Exception e)
        {
            Debug.LogError($"移除节点异常：{e}");
            return false;
        }
    }

    public bool RemoveNode(int nIndex)
    {
        if (nIndex < Child.Count)
        {
            Child.RemoveAt(nIndex);
            return true;
        }
        return false;
    }

    public abstract override bool Play(bool IsOverride = false);

    public override void Stop()
    {
        if (Child != null)
        {
            for (int i = 0; i < Child.Count; i++)
            {
                Child[i].Stop();
            }
        }
    }
}

/// <summary>
/// 行为节点父类
/// </summary>
public abstract class ActionController : TreeNode
{
    private string mActionTag;
    public ActionController(int rPriority, bool bIsWorld)
    {
        this.NodeType = NodeType.ActionNode;
        this.Priority = rPriority;
    }

    public override bool AddNode(TreeNode rNode)
    { return false; }

    public override void Init()
    {
        this.NodeType = NodeType.ActionNode;
    }

    public override void OnDestory()
    {
    }

    public override bool Play(bool IsOverride = false)
    {
        if (this.CheckSelf())
        {
            this.mIsPlay = true;
            //if (bIsWorldTag)
            //    WorldModel.Instance.SetTagIsPlayed(this.mTag);
            //else
            //    this.Model.SetTagIsPlayed(this.mTag);
            this.Action();
            return true;
        }
        return false;
    }

    public override void Stop() { if (mIsPlay) { mIsPlay = false; this.ActionEnd(); } }

    public override int IsPlay() { return mIsPlay ? 1 : 0; }

    protected void Action()
    {
        BehaviorTreeController.Instance.SetAction(TreeID, mActionTag, new Red() { IsEnd = false, SignName = mActionTag });
    }

    protected abstract void ActionEnd();
}

