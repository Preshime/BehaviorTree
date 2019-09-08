using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Go4Player : AIAction
{
    public string SignName { get; set; }
    public bool IsEnd { get; set; }

    private EnemyController mEC;

    public void OnUpdate(GameObject rGO)
    {
        if (mEC == null)
            mEC = rGO.GetComponent<EnemyController>();

        Vector3 rAsp;
        rAsp = (mEC.Player.transform.position - mEC.transform.position).normalized;

        mEC.NowSpeed = mEC.NowSpeed >= mEC.Speed ? mEC.Speed : (mEC.NowSpeed + mEC.AddSpeed);
        mEC.mCC.Move(rAsp * mEC.NowSpeed);
        if (Vector3.Distance(mEC.transform.position, mEC.Player.transform.position) < 0.3)
            IsEnd = true;
    }
}
