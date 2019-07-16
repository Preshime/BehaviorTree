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

    public NodeType Type;

    public int Priority;

    protected TreeNode Parent;
    protected List<TreeNode> Child;
    protected abstract void Init();
    protected abstract void OnDestory();
    public abstract int IsPlay();
}

//待扩展
public enum NodeType
{
    Base,
    ActionNode,
    QueueNode,
    ParallelNode,
    ParallelByNumNode,

}

/// <summary>
/// 控制节点父类，待进一步细化
/// </summary>
public abstract class ControllerNode : TreeNode
{
    protected override void Init()
    {
        Child = new List<TreeNode>();
    }

    protected override void OnDestory()
    {
        Child.Clear();
    }

    protected abstract bool CheckSelf();

    protected abstract void FindChild();

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

    public abstract override int IsPlay();
}

/// <summary>
/// 行为节点父类，待实例化
/// </summary>
public abstract class ActionController : TreeNode
{
    private bool isPlay;

    protected override void Init()
    {
        Type = NodeType.ActionNode;
    }

    protected override void OnDestory()
    {
    }

    protected void Play() { isPlay = true; }

    protected void Stop() { isPlay = false; }

    public override int IsPlay() { return isPlay ? 1 : 0; }
}

