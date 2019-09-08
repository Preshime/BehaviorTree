using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private AIAction mAction;

    public float Speed;
    public float AddSpeed;

    public Vector3 StartPos;
    public Vector3 EndPos;

    [HideInInspector]
    public CharacterController mCC;
    [HideInInspector]
    public float NowSpeed;
    [HideInInspector]
    public bool ToStart = true;

    void Start()
    {
        mCC = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        mAction.OnUpdate(this.gameObject);
    }
}
