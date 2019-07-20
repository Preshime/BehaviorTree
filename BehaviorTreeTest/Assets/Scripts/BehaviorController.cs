
using System.Collections.Generic;
using UnityEngine;

public class BehaviorController : MonoBehaviour
{
    private BaseNode behavior;

    private void Start()
    {
        if (behavior == null)
            behavior = new BaseNode();

        behavior.Model = new NodeModel();
        behavior.Model.SetValue("queue", "111");
        behavior.Model.SetValue("action2", true);
        behavior.Model.SetValue("action", true);
        behavior.Model.SetValue("single", 2);

        var act21 = new ActionTest2(1);
        act21.Name = "act2-0-1";
        behavior.AddNode(act21);

        var act22 = new ActionTest2(5);
        act22.Name = "act2-0-2";
        behavior.AddNode(act22);


        var con1 = new SingleTest(2);
        con1.Name = "conSingle-0-3";
        behavior.AddNode(con1);

        var act11 = new ActionTest();
        act11.Name = "act1-0-3-1";
        con1.AddNode(act11);

        var con3 = new QueueTest();
        con3.Name = "conQueue-0-3-2";
        con1.AddNode(con3);

        var act23 = new ActionTest2();
        act23.Name = "act2-0-3-2-1";
        con3.AddNode(act23);

        var act24 = new ActionTest2();
        act24.Name = "act2-0-3-2-2";
        con3.AddNode(act24);


        //var con2 = new QueueTest();
        //con2.Name = "conQueue-0-4";


    }

    public void StartBase()
    {
        if (behavior.IsPlay() == 0) behavior.Play();
        else behavior.Stop();
    }

    private void Update()
    {
        // Debug.Log("updating");
    }
}

