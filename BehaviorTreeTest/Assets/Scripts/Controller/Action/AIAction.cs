using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface AIAction
{
    string SignName { get; set; }
    bool IsEnd { get; set; }
    void OnUpdate(GameObject rGO);
}
