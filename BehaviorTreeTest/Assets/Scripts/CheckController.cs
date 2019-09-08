using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckController : MonoBehaviour
{
    public GameObject Player;

    public List<EnemyController> Enemys;

    void Update()
    {
        for (int i = 0; i < Enemys.Count; i++)
        {
            if (Vector3.Distance(Enemys[i].transform.position, Player.transform.position) < 5)
                BehaviorTreeController.Instance.BaseNodeList[Enemys[i].TreeID].Model.SetValue("Go4Player", true);

            else
                BehaviorTreeController.Instance.BaseNodeList[Enemys[i].TreeID].Model.SetValue("MoveAround", true);
        }
    }
}
