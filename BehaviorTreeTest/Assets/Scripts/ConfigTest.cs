using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigTest : MonoBehaviour
{
    private ConfigTest() { }

    public static ConfigTest Instance { get; private set; }

    public Dictionary<int, Dictionary<int, List<string>>> TreeDic = new Dictionary<int, Dictionary<int, List<string>>>();
    public Dictionary<int, string> NodeName = new Dictionary<int, string>();

    void Start()
    {
        Instance = this;
        Init();
    }

    public void Init()
    {
        //1:                //树的ID
        //[0,0,0,1.2.3;     //节点信息  id，种类，传入参数，子节点id
        //1,1,2,;           //其中父节点的第一位仍表示id，但是没有意义，建议试用树id作为父节点id
        //2,2,1,4.5;        //种类指通过另一个表/文件对应至string然后反射指向一个test类
        //3,1,1,;
        //4,2,,;
        //5,2,2,;]
        //2:
        //[]
        TextAsset rConfig = Resources.Load("Config") as TextAsset;
        string rt = rConfig.text.Replace("\n", "");
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
            TreeDic.Add(nTreeID, rMsgDic);
        }

        TextAsset rNode = Resources.Load("NodeConfig") as TextAsset;
        rt = rNode.text.Replace("\n", "");
        rt = rt.Replace("\r", "");
        ss = rt.Split(';');
        for (int i = 0; i < ss.Length; i++)
        {
            string[] rNodeMsg = ss[i].Split(':');
            if (!string.IsNullOrEmpty(rNodeMsg[0]))
            {
                int nNodeID = int.Parse(rNodeMsg[0]);
                string rNodeName = rNodeMsg[1];
                NodeName.Add(nNodeID, rNodeName);
            }
        }
        Debug.Log("配置加载完成");
        BehaviorTreeController.Instance.CreateTree();
    }


    // Update is called once per frame
    void Update()
    {

    }
}

