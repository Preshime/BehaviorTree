using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


public class RefleTest
{
    public static ConfigTest configTest => ConfigTest.Instance;



    //public TreeNode ProClass(int key, Dictionary<int, List<string>> rTreesMsg)
    //{

    //    TreeNode rTree = (TreeNode)Activator.CreateInstance(Type.GetType(configTest.NodeName[int.Parse(rTreesMsg[key][1])]));
    //    rTree.ID = key;
    //    rTree.Priority = int.Parse(rTreesMsg[key][2]);
    //    if (rTreesMsg[key][3] != "")
    //    {
    //        List<string> cNodes = new List<string>(rTreesMsg[key][3].Split('.'));
    //        for (int i = 0; i < cNodes.Count; i++)
    //        {
    //            rTree.AddNode(/*this.ProClass(int.Parse(cNodes[i]), rTreesMsg)*/);
    //        }
    //    }
    //    return rTree;

    //}

    public static BaseNode CreateTree(BaseNode rBase, int nTreeID, List<string> rTreesMsg)
    {
        if (rTreesMsg[3] != "")
        {
            List<string> cNodes = new List<string>(rTreesMsg[3].Split('.'));
            for (int i = 0; i < cNodes.Count; i++)
            {
                int ID = int.Parse(cNodes[i]);
                rBase.AddNode(CreateNode(nTreeID, ID, configTest.TreeDic[nTreeID][ID])/*this.ProClass(int.Parse(cNodes[i]), rTreesMsg)*/);
            }
        }
        return rBase;
    }

    public static TreeNode CreateNode(int nTreeID, int key, List<string> rTreesMsg)
    {
        string s;
        s = configTest.NodeName[int.Parse(rTreesMsg[1])];
        Debug.Log(s);
        TreeNode rTree = (TreeNode)Activator.CreateInstance(Type.GetType(s));
        rTree.ID = key;
        rTree.Priority = int.Parse(rTreesMsg[2]);
        if (rTreesMsg[3] != "")
        {
            List<string> cNodes = new List<string>(rTreesMsg[3].Split('.'));
            for (int i = 0; i < cNodes.Count; i++)
            {
                int ID = int.Parse(cNodes[i]);
                rTree.AddNode(CreateNode(nTreeID, ID, configTest.TreeDic[nTreeID][ID])/*this.ProClass(int.Parse(cNodes[i]), rTreesMsg)*/);
            }
        }

        return rTree;
    }
}