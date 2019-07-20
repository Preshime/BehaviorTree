using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseNode : ControllerNode
{
    public BaseNode()
    {
        NodeType = NodeType.Base;
        this.Priority = 0;
    }

    public override bool CheckSelf()
    {
        return true;
    }

    public override int IsPlay()
    {
        if (Child != null)
        {
            int num = 0;
            for (int i = 0; i < Child.Count; i++)
            {
                if (Child[i].IsPlay() > 0)
                {
                    num++;
                }
            }
            return num;
        }
        return 0;
    }

    public override void Play(bool IsOverride = false)
    {
        if (Child != null)
        {
            for (int i = 0; i < Child.Count; i++)
            {
                Child[i].Play();
            }
        }
    }
}
