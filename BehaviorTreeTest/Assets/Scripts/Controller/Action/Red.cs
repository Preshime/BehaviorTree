using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : AIAction
{
    MeshRenderer mMR;

    public string SignName { get; set; }
    public bool IsEnd { get; set; }

    public void OnUpdate(GameObject rGO)
    {
        if (mMR == null)
            mMR = rGO.GetComponent<MeshRenderer>();

        mMR.material.color = Color.red;
    }
}
