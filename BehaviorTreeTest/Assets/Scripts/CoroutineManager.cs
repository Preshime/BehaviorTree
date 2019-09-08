using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : MonoBehaviour
{
    public static CoroutineManager Instance { get; private set; }

    private void Awake()
    {
        Instance = new CoroutineManager();
    }

    void Start()
    {

    }

    public void Start(IEnumerator rIE)
    {
        this.StartCoroutine(rIE);
    }

}
