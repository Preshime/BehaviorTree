
using System.Collections.Generic;
using UnityEngine;

public interface BehaviorController
{
    void Init();
    void Play();
    void Stop();
    void OnDestory();

}

public class TBehaviorController : BehaviorController
{
    //下属控制器列表
    List<BehaviorController> rControllerList;
    //下属行为列表
    List<string> rAction;

    public void Init()
    {
        Debug.Log("Controller Init");
    }

    public void Play()
    {
        Debug.Log("Controller Play");
    }

    public void Stop()
    {
        Debug.Log("Controller Stop");
    }

    public void OnDestory()
    {
        Debug.Log("Controller Destory");
    }
}