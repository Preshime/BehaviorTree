using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : MonoBehaviour
{
    private static CoroutineManager _Instance;

    public static CoroutineManager Instance
    {
        get
        {
            if (_Instance == null)
                _Instance = new CoroutineManager();
            return _Instance;
        }
    }

    public void Start(IEnumerator rIE)
    {
        this.StartCoroutine(rIE);
    }
}
