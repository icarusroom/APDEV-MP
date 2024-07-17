using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadEventArgs : EventArgs
{
    private Touch[] _trackedFingers;
    private float _distanceDelta;
    private GameObject _hitObject;

    public Touch[] TrackedFingers
    {
        get { return this._trackedFingers; }
        set { this._trackedFingers = value; }
    }

    public float DistanceDelta
    {
        get { return this._distanceDelta; }
        set { this._distanceDelta = value; }    
    }


    public GameObject HitObject
    {
        get { return this._hitObject; }
        set { this._hitObject = value; }   
    }

    public SpreadEventArgs(float _distanceDelta, GameObject hitObject = null)
    {
        this._distanceDelta = _distanceDelta;
        this._hitObject = hitObject;
    }

    public SpreadEventArgs(Touch[] trackedFingers, float _distanceDelta, GameObject hitObject = null)
    {
        this._trackedFingers = trackedFingers;
        this._distanceDelta = _distanceDelta;
        this._hitObject = hitObject;
    }
}
