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

    public NodeModel Model;

    protected bool isPlay;

    protected TreeNode Parent;
    protected List<TreeNode> Child;

    public TreeNode(TreeNode Parent)
    {
        this.Parent = Parent;
        Init();
        if (Parent != null)
            this.Model = Parent.Model;
    }

    public abstract void Init();
    public abstract void OnDestory();
    public abstract int IsPlay();
    public abstract void Play(bool IsOverride = false);
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
/// 控制节点父类，待进一步细化
/// </summary>
public abstract class ControllerNode : TreeNode
{
    public ControllerNode(TreeNode Parent) : base(Parent)
    {
    }

    public abstract override int IsPlay();

    public override void Init()
    {
        Child = new List<TreeNode>();
    }

    public override void OnDestory()
    {
        Child.Clear();
    }

    protected bool AddNode(TreeNode rNode)
    {
        try
        {
            if (Child == null) Child = new List<TreeNode>();
            if (Child.Count == 0)
                Child.Add(rNode);
            else
            {
                for (int i = 0; i < Child.Count; i++)
                {
                    if (Child[i].Priority < rNode.Priority)
                    {
                        Child.Insert(i, rNode);
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"增加节点失败:{e}");
        }
        return true;
    }

    protected bool RemoveNode(TreeNode rNode)
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

    protected bool RemoveNode(int nIndex)
    {
        if (nIndex < Child.Count)
        {
            Child.RemoveAt(nIndex);
            return true;
        }
        return false;
    }

    public abstract override void Play(bool IsOverride = false);

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
/// 行为节点父类，待实例化
/// </summary>
public abstract class ActionController : TreeNode
{
    public ActionController(TreeNode Parent) : base(Parent)
    {
    }

    public override void Init()
    {
        NodeType = NodeType.ActionNode;
    }

    public override void OnDestory()
    {
    }

    public override void Play(bool IsOverride = false) { if (IsOverride || !isPlay) isPlay = true; this.Action(); }

    public override void Stop() { isPlay = false; this.ActionEnd(); }

    public override int IsPlay() { return isPlay ? 1 : 0; }

    protected abstract void Action();

    protected abstract void ActionEnd();
}

