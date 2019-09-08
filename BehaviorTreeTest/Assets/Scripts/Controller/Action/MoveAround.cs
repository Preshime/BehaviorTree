using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : AIAction
{
    private EnemyController mEC;

    public MoveAround()
    {
        Debug.Log("创建了一个巡逻");
    }

    public bool IsEnd { get; set; }
    public string SignName { get; set; }

    public void OnUpdate(GameObject rGO)
    {
        //巡逻
        Vector3 rAsp;
        if (mEC.ToStart)
            rAsp = (mEC.StartPos - mEC.transform.position).normalized;
        else
            rAsp = (mEC.EndPos - mEC.transform.position).normalized;

        mEC.NowSpeed = mEC.NowSpeed >= mEC.Speed ? mEC.Speed : (mEC.NowSpeed + mEC.AddSpeed);
        mEC.mCC.Move(rAsp * mEC.NowSpeed);
        if (mEC.ToStart && Vector3.Distance(mEC.transform.position, mEC.StartPos) < 0.3)
            mEC.ToStart = false;

        else if (!mEC.ToStart && Vector3.Distance(mEC.transform.position, mEC.EndPos) < 0.3)
            mEC.ToStart = true;
    }
}
