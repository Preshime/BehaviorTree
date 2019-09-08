using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldModel : NodeModel
{
    private WorldModel(TreeNode rNode) : base(null)
    {
    }

    private WorldModel() { }

    private static WorldModel _Instance;
    public static WorldModel Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = new WorldModel();
            }
            return _Instance;
        }
    }
}
