using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class RotateProperty


{
    private float _minDistance = 0.75f;

    public float MinDistance
    {
        get { return _minDistance; }    
        set { _minDistance = value; }
    }

    private float _minRotationChange = 0.4f;

    public float MinRotationChange
    {
        get { return _minRotationChange; }
        set { _minRotationChange = value; }
    }
}
