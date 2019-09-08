using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTreeController : MonoBehaviour
{
    public static BehaviorTreeController Instance { get; private set; }

    public Dictionary<int, BaseNode> BaseNodeList = new Dictionary<int, BaseNode>();
    Dictionary<int, Dictionary<string, AIAction>> mAllMsg = new Dictionary<int, Dictionary<string, AIAction>>();

    void Awake()
    {
        Instance = this;
    }

    public void OnUpdate()
    {
        WorldModel.Instance.OnUpdate();
        foreach (var i in BaseNodeList)
        {
            BaseNodeList[i.Key].Play();
            BaseNodeList[i.Key].Model.OnUpdate();
        }
    }


    public void CreateTree()
    {
        var rTreesMsg = ConfigTest.Instance.TreeDic;
        foreach (var rTreeMsg in rTreesMsg)
        {
            BaseNode rTreeBase = new BaseNode()
            {
                TreeID = rTreeMsg.Key,
            };
            rTreeBase.Model = new NodeModel(rTreeBase);

            this.BaseNodeList.Add(rTreeMsg.Key, RefleTest.CreateTree(rTreeBase, rTreeBase.TreeID, rTreeMsg.Value[0]));
            this.mAllMsg.Add(rTreeBase.TreeID, new Dictionary<string, AIAction>());
        }
    }


    /// <summary>
    /// 获取状态动作的名字
    /// </summary>
    /// <param name="nTreeID"></param>
    /// <param name="rSignName"></param>
    /// <returns></returns>
    public AIAction GetAction(int nTreeID, string rSignName)
    {
        Dictionary<string, AIAction> rTree;
        mAllMsg.TryGetValue(nTreeID, out rTree);
        AIAction rAction;
        if (rTree.TryGetValue(rSignName, out rAction))
            return rAction;
        else
            return null;
    }

    /// <summary>
    /// 设置状态动作
    /// </summary>
    /// <param name="nTreeID"></param>
    /// <param name="rSignName"></param>
    /// <param name="rAction"></param>
    public void SetAction(int nTreeID, string rSignName, AIAction rAction)
    {
        Dictionary<string, AIAction> rTree;
        mAllMsg.TryGetValue(nTreeID, out rTree);
        if (rTree.ContainsKey(rSignName))
        {
            rTree[rSignName] = rAction;
        }
        else
            rTree.Add(rSignName, rAction);
    }

    /// <summary>
    /// 动作完成
    /// </summary>
    /// <param name="nTreeID"></param>
    /// <param name="rSignName"></param>
    public void SetActionEnd(int nTreeID, string rSignName)
    {
        Dictionary<string, AIAction> rTree;
        mAllMsg.TryGetValue(nTreeID, out rTree);
        if (rTree.ContainsKey(rSignName))
        {
            rTree.Remove(rSignName);
        }
    }
}
