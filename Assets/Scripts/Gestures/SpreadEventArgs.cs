using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadEventArgs : MonoBehaviour
{
    private Touch[] _trackedFingers;

    public Touch[] TrackedFingers
    {
        get { return this._trackedFingers; }
    }

    private float _distanceDelta;

    public float DistanceDelta
    {
        get { return this._distanceDelta; }
    }

    private GameObject _hitObject;

    public GameObject HitObject
    {
        get { return this._hitObject; }
    }

    public SpreadEventArgs(float _distanceDelta)
    {
        this._distanceDelta = _distanceDelta;
    }

    public SpreadEventArgs(Touch[] trackedFingers, float _distanceDelta, GameObject hitObject = null)
    {
        this._trackedFingers = trackedFingers;
        this._distanceDelta = _distanceDelta;
        this._hitObject = hitObject;
    }
}
