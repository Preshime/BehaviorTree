using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckController : MonoBehaviour
{
    public GameObject Player;

    public List<EnemyController> Enemys;


    void Update()
    {
        int ii = 0;
        if (ii == 0)
        {
            WorldModel.Instance.SetValue("Parallel", "111");
            WorldModel.Instance.SetValue("Red", false);
        }
        for (int i = 0; i < Enemys.Count; i++)
        {
            var r = BehaviorTreeController.Instance.BaseNodeList[Enemys[i].TreeID].Model;
            r.SetValue("single", 1);
            bool b;
            if (Vector3.Distance(Enemys[i].transform.position, Player.transform.position) < 5)
            {
                if (!r.TryGetValue("Go4Player", out b) || !b)
                {
                    r.SetValue("MoveAround", false);
                    r.SetValue("Go4Player", true);
                }
            }

            else
            {
                if (!r.TryGetValue("MoveAround", out b) || !b)
                {
                    r.SetValue("MoveAround", true);
                    r.SetValue("Go4Player", false);
                }
            }
        }
        BehaviorTreeController.Instance.OnUpdate();
    }
}
