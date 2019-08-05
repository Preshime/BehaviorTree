using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

//父类
public abstract class TreeNode
{
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

    protected bool isPlay;

    public TreeNode Parent;
    protected List<TreeNode> Child;

    public abstract void Init();
    public abstract void OnDestory();
    public abstract int IsPlay();
    public abstract bool Play(bool IsOverride = false);
    public abstract void Stop();
    public abstract bool CheckSelf();
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

    public bool AddNode(TreeNode rNode)
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
    public ActionController(int Priority) { NodeType = NodeType.ActionNode; this.Priority = Priority; }

    public override void Init()
    {
        NodeType = NodeType.ActionNode;
    }

    public override void OnDestory()
    {
    }

    public override bool Play(bool IsOverride = false)
    {
        if ((IsOverride || !isPlay) && CheckSelf())
        {
            isPlay = true;
            this.Action();
            return true;
        }
        return false;
    }

    public override void Stop() { if (isPlay) { isPlay = false; this.ActionEnd(); } }

    public override int IsPlay() { return isPlay ? 1 : 0; }

    protected abstract void Action();

    protected abstract void ActionEnd();
}

