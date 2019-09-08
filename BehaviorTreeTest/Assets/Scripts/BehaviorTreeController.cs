using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTreeController : MonoBehaviour
{
    public static BehaviorTreeController Instance { get; private set; }

    Dictionary<int, BaseNode> mBaseNodeList = new Dictionary<int, BaseNode>();
    Dictionary<int, Dictionary<string, AIAction>> mAllMsg = new Dictionary<int, Dictionary<string, AIAction>>();

    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        WorldModel.Instance.OnUpdate();
        for (int i = 0; i < mBaseNodeList.Count; i++)
        {
            mBaseNodeList[i].Play();
            mBaseNodeList[i].Model.OnUpdate();
        }
    }


    public void CreateTree(Dictionary<int, Dictionary<int, List<string>>> rTreesMsg)
    {
        foreach (var rTreeMsg in rTreesMsg)
        {
            BaseNode rTreeBase = new BaseNode()
            {
                ID = rTreeMsg.Key,
            };
            rTreeBase.Model = new NodeModel(rTreeBase);
            this.mBaseNodeList.Add(rTreeMsg.Key, rTreeBase);
        }
    }

    /// <summary>
    /// 获取状态动作的名字
    /// </summary>
    /// <param name="nTreeID"></param>
    /// <param name="rSignName"></param>
    /// <returns></returns>
    public AIAction GetActionName(int nTreeID, string rSignName)
    {
        Dictionary<string, AIAction> rTree;
        mAllMsg.TryGetValue(nTreeID, out rTree);
        AIAction rAction;
        rTree.TryGetValue(rSignName, out rAction);
        return rAction;
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
    }
}
