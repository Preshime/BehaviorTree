using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    private Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        if (player != null)
            distance = this.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player != null)
            this.transform.position = player.transform.position + distance;
    }
}
