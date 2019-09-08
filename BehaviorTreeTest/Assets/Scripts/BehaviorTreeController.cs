using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTreeController : MonoBehaviour
{
    List<BaseNode> mBaseNodeList = new List<BaseNode>();


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
            this.mBaseNodeList.Add(rTreeBase);
        }
    }
}
