using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanEventArgs : EventArgs
{ 
    private Touch[] _trackedFingers;

    public Touch[] TrackedFingers
    {
        get { return this._trackedFingers; }
        set { this._trackedFingers = value; }
    }

    public PanEventArgs(Touch[] trackedFinger)
    {
        this._trackedFingers = trackedFinger;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
