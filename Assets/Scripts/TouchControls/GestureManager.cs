using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureManager : MonoBehaviour
{
    public static GestureManager Instance;

    private Touch[] _trackedFingers = new Touch[2];
    private float _gestureTime = 0;
    private Vector2 _startPoint = Vector2.zero;
    private Vector2 _endPoint = Vector2.zero;

    [SerializeField]
    private TapProperty _tapProperty;
    public EventHandler<TapEventArgs> OnTap;

    private void CheckTap()
    {
        if(this._gestureTime <= this._tapProperty.Time && Vector2.Distance(this._startPoint, this._endPoint) <= (Screen.dpi * this._tapProperty.MaxDistance))
        {
            this.FireTapEvent();
        }
    }

    private void FireTapEvent()
    {
        GameObject hitObject = this.GetHitObject(this._startPoint);
        TapEventArgs args = new TapEventArgs(this._startPoint, hitObject);

        if(this.OnTap != null)
        {
            this.OnTap(this, args);
        }

        if(hitObject != null)
        {
            ITappable handler = hitObject.GetComponent<ITappable>();
            if(handler != null)
            {
                handler.OnTap(args);
            }
        }
    }

    private void CheckSingleFingerInput()
    {
        this._trackedFingers[0] = Input.GetTouch(0);

        switch(this._trackedFingers[0].phase)
        {
            case TouchPhase.Began:
                this._startPoint = this._trackedFingers[0].position;
                this._gestureTime = 0;
                break;
            case TouchPhase.Ended:
                this._endPoint = this._trackedFingers[0].position;
                this.CheckTap();
                //this.CheckSwipe();
                break;

            default:
                this._gestureTime += Time.deltaTime;
                //this.CheckDrag();
                break;
        }
    }

    private void CheckDualFingerInput()
    {
        this._trackedFingers[0] = Input.GetTouch(0);
        this._trackedFingers[1] = Input.GetTouch(1);

        /*
        switch(this._trackedFingers[0].phase, this._trackedFingers[1].phase)
        {
            case(TouchPhase.Moved, TouchPhase.Moved):
                this.CheckPan();
                break;
        }
        */

        if(this._trackedFingers[0].phase == TouchPhase.Moved && this._trackedFingers[0].phase == TouchPhase.Moved)
        {

        }
        if (this._trackedFingers[0].phase == TouchPhase.Moved || this._trackedFingers[0].phase == TouchPhase.Moved)
        {

        }
    }
    private GameObject GetHitObject(Vector2 screenPoint)
    {
        GameObject hitObject = null;
        Ray ray = Camera.main.ScreenPointToRay(this._startPoint);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            hitObject = hit.collider.gameObject;
        }

        return hitObject;
    }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        switch(Input.touchCount)
        {
            case 1: CheckSingleFingerInput();
                break;
            case 2: CheckDualFingerInput();
                break;
        }
    }

}
