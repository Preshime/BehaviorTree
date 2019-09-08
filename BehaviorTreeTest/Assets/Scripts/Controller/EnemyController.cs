using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private List<AIAction> mActions = new List<AIAction>();

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
    }

    void Update()
    {
        for (int i = 0; i < mActions.Count; i++)
        {
            //判断行为
            if (mActions[i] != BehaviorTreeController.Instance.GetAction(TreeID, mActions[i].SignName))
                mActions[i] = BehaviorTreeController.Instance.GetAction(TreeID, mActions[i].SignName);
            //进行行为
            mActions[i]?.OnUpdate(this.gameObject);
        }
        //是否结束
        List<AIAction> rCopy = new List<AIAction>();
        rCopy.AddRange(mActions);
        foreach (var rA in rCopy)
        {
            if (rA.IsEnd)
            {
                BehaviorTreeController.Instance.SetActionEnd(TreeID, rA.SignName);
                this.mActions.Remove(rA);
            }
        }
    }
}
