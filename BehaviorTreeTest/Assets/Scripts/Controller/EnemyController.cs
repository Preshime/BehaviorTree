using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Dictionary<string, AIAction> mActions = new Dictionary<string, AIAction>();

    public float Speed;
    public float AddSpeed;

    public Vector3 StartPos;
    public Vector3 EndPos;

    public GameObject Player;

    [HideInInspector]
    public CharacterController mCC;
    [HideInInspector]
    public float NowSpeed;
    [HideInInspector]
    public bool ToStart = true;

    public int TreeID;


    void Start()
    {
        this.mCC = this.GetComponent<CharacterController>();
        this.mActions.Add("Move", null);
        this.mActions.Add("Color", null);
    }

    void Update()
    {
        List<string> rList = new List<string>();
        foreach (var r in mActions)
        {
            rList.Add(r.Key);
        }
        foreach (var rKey in rList)
        {
            //判断行为
            if (mActions[rKey] != BehaviorTreeController.Instance.GetAction(TreeID, rKey))
                mActions[rKey] = BehaviorTreeController.Instance.GetAction(TreeID, rKey);
            //进行行为
            mActions[rKey]?.OnUpdate(this.gameObject);
            //是否结束
            if (mActions[rKey]?.IsEnd ?? false)
            {
                BehaviorTreeController.Instance.SetActionEnd(TreeID, rKey);
                mActions[rKey] = null;
            }
        }
    }
}
