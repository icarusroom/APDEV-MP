using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PanProperty
{
    [Tooltip("MaxDistance between fingers to be a pan")]
    [SerializeField]
    private float _maxDistance = 0.7f;

    public float MaxDistance
    {
        get { return this._maxDistance; }
        set { this._maxDistance = value; }
    }
}
