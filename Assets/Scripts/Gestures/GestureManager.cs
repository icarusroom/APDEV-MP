using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class GestureManager : MonoBehaviour
{
    public static GestureManager Instance;
    private Touch _trackedFinger;
    private Touch[] _trackedFingers = new Touch[2]; // Initialize the array
    private float _gestureTime;

    [SerializeField] private TapProperty _tapProperty;
    public EventHandler<TapEventArgs> OnTap;

    [SerializeField] private SwipeProperty _swipeProperty;
    public EventHandler<SwipeEventArgs> OnSwipe;

    [SerializeField] private DragProperty _dragProperty;
    public EventHandler<DragEventArgs> OnDrag;

    [SerializeField] private PanProperty _panProperty;
    public EventHandler<PanEventArgs> OnPan;

    [SerializeField] private SpreadProperty _spreadProperty;
    public EventHandler<SpreadEventArgs> OnSpread;

    private Vector2 _startPoint = Vector2.zero;
    private Vector2 _endPoint = Vector2.zero;

    private void Update()
    {
        switch (Input.touchCount)
        {
            case 1:
                Debug.Log("Called Single Finger Input");
                CheckSingleFingerInput();
                break;

            case 2:
                Debug.Log("Called Dual Finger Input");
                CheckDualFingerInput();
                break;
        }
    }

    private void CheckTap()
    {
        if (this._gestureTime <= this._tapProperty.Time && Vector2.Distance(this._startPoint, this._endPoint) <=
          (Screen.dpi * this._tapProperty.MaxDistance))
        {
            this.FireTapEvent();
        }
    }

    private void FireTapEvent()
    {
        GameObject hitObject = this.GetHitObject(this._startPoint);
        TapEventArgs args = new TapEventArgs(this._startPoint, hitObject);

        if (this.OnTap != null)
        {
            this.OnTap(this, args);

            if (hitObject != null)
            {
                ITappable handler = hitObject.GetComponent<ITappable>();
                if (handler != null)
                {
                    handler.OnTap(args);
                }
            }
        }
    }

    private void CheckSwipe()
    {
        Debug.Log("Check Swipe Called");
        if (this._gestureTime <= this._swipeProperty.Time && Vector2.Distance(this._startPoint, this._endPoint) >=
        (Screen.dpi * this._swipeProperty.MinDistance))
        {
            this.FireSwipeEvent();
        }
    }

    private void FireSwipeEvent()
    {
        Vector2 rawDirection = this._endPoint - this._startPoint;
        ESwipeDirection direction = this.GetSwipeDirection(rawDirection);
        GameObject hitObject = this.GetHitObject(this._startPoint);
        SwipeEventArgs args = new SwipeEventArgs(direction, rawDirection, this._startPoint);

        if (this.OnSwipe != null)
        {
            this.OnSwipe(this, args);

            if (hitObject != null)
            {
                ISwipeable handler = hitObject.GetComponent<ISwipeable>();
                if (handler != null)
                {
                    handler.OnSwipe(args);
                }
            }
        }
    }

    private void CheckDrag()
    {
        if (this._gestureTime >= this._dragProperty.Time)
        {
            this.FireDragEvent();
        }
    }

    private void FireDragEvent()
    {
        Vector2 position = this._trackedFinger.position;
        GameObject hitObject = this.GetHitObject(position);
        DragEventArgs args = new DragEventArgs(this._trackedFinger, hitObject);

        if (this.OnDrag != null)
        {
            this.OnDrag(this, args);
        }

        if (hitObject != null)
        {
            IDraggable handler = hitObject.GetComponent<IDraggable>();
            if (handler != null)
            {
                handler.OnDrag(args);
            }
        }
    }

    private void CheckPan()
    {
        if (Vector2.Distance(this._trackedFingers[0].position, this._trackedFingers[1].position) <=
        (Screen.dpi * this._panProperty.MaxDistance))
        {
            this.FirePanEvent();
        }
    }

    private void FirePanEvent()
    {
        PanEventArgs args = new PanEventArgs(this._trackedFingers);

        if (this.OnPan != null)
        {
            this.OnPan(this, args);
        }
    }

    private void CheckSpread()
    {
        /* Distance between fingers’ previous positions. */
        float previousDistance = Vector2.Distance(GetPreviousPoint(this._trackedFingers[0]), GetPreviousPoint(this._trackedFingers[1]));

        /* Distance between fingers’ current positions. */
        float currentDistance = Vector2.Distance(this._trackedFingers[0].position, this._trackedFingers[1].position);

        if (Mathf.Abs(currentDistance - previousDistance) >= this._spreadProperty.MinDistanceChange)
        {
            this.FireSpreadEvent(Mathf.Abs(currentDistance - previousDistance));
        }
    }

    private void FireSpreadEvent(float distanceDelta)
    {
        SpreadEventArgs args = new SpreadEventArgs(distanceDelta);

        if (this.OnSpread != null)
        {
            this.OnSpread(this, args);
        }

        Vector2 objPos = (this._trackedFingers[0].position + this._trackedFingers[1].position) / 2;
        GameObject hitObject = this.GetHitObject(objPos);

        if (hitObject != null)
        {
            ISpreadable handler = hitObject.GetComponent<ISpreadable>();
            if (handler != null)
            {
                handler.OnSpread(args);
            }
        }
    }

    private Vector2 GetPreviousPoint(Touch finger)
    {
        return finger.position - finger.deltaPosition;
    }

    private ESwipeDirection GetSwipeDirection(Vector2 rawDirection)
    {
        if (Math.Abs(rawDirection.x) > Math.Abs(rawDirection.y))
        {
            if (rawDirection.x > 0)
            {
                return ESwipeDirection.RIGHT;
            }
            else
            {
                return ESwipeDirection.LEFT;
            }
        }
        else
        {
            if (rawDirection.y > 0)
            {
                return ESwipeDirection.UP;
            }
            else
            {
                return ESwipeDirection.DOWN;
            }
        }
    }

    private void CheckSingleFingerInput()
    {
        this._trackedFinger = Input.GetTouch(0);

        switch (this._trackedFinger.phase)
        {
            case TouchPhase.Began:
                this._startPoint = this._trackedFinger.position;
                this._gestureTime = 0;
                break;

            case TouchPhase.Ended:
                this._endPoint = this._trackedFinger.position;
                this.CheckTap();
                this.CheckSwipe();
                break;

            default:
                this._gestureTime += Time.deltaTime;
                this.CheckDrag();
                break;
        }
    }

    private void CheckDualFingerInput()
    {
        this._trackedFingers[0] = Input.GetTouch(0);
        this._trackedFingers[1] = Input.GetTouch(1);

        if (this._trackedFingers[0].phase == TouchPhase.Moved && this._trackedFingers[1].phase == TouchPhase.Moved)
        {
            this.CheckPan();
        }

        if (this._trackedFingers[0].phase == TouchPhase.Moved || this._trackedFingers[1].phase == TouchPhase.Moved)
        {
            this.CheckSpread();
        }
    }

    private GameObject GetHitObject(Vector2 screenPoint)
    {
        GameObject hitObject = null;
        Ray ray = Camera.main.ScreenPointToRay(screenPoint);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            hitObject = hit.collider.gameObject;
        }

        return hitObject;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
