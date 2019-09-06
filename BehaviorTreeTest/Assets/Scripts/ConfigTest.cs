﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigTest : MonoBehaviour
{

    Dictionary<int, Dictionary<int, List<string>>> rTreeDic = new Dictionary<int, Dictionary<int, List<string>>>();
    void Start()
    {
        Init();
    }

    public void Init()
    {
        TextAsset r = Resources.Load("Config") as TextAsset;
        string rt = r.text.Replace("\n", "");
        rt = rt.Replace("\r", "");
        string[] ss = rt.Split(':');
        for (int i = 0; i < ss.Length - 1; i++)
        {
            int nTreeID = int.Parse(ss[i]);
            int nIndex = ss[i + 1].IndexOf(']');
            string rTree = ss[i + 1].Substring(ss[i + 1].IndexOf('[') + 1, nIndex - 1);
            ss[1] = ss[i + 1].Substring(nIndex + 1);
            string[] rAll = rTree.Split(';');
            Dictionary<int, List<string>> rMsgDic = new Dictionary<int, List<string>>();
            foreach (string rMsg in rAll)
            {
                string s = rMsg;
                List<string> rMsgArr = new List<string>(s.Split(','));
                if (!string.IsNullOrEmpty(rMsgArr[0]))
                {
                    int nID = int.Parse(rMsgArr[0]);
                    rMsgDic.Add(nID, rMsgArr);
                }
            }
            rTreeDic.Add(nTreeID, rMsgDic);
        }
        Debug.Log(1111);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
