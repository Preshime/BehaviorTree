using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public PlayerController player;

    private Vector3 distance;

    void Start()
    {
        if (player != null)
            distance = player.transform.position - this.transform.position;
    }

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 rEndDis = distance;
            if (player.IsMoving)
                rEndDis -= rEndDis.normalized * 1f;
            this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position - rEndDis, 0.1f);
        }
    }
}
