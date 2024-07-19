using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanReceiver : MonoBehaviour
{
    private float _speed = 50.0f;
    private bool isPanning = false;

    public void OnPan(object sender, PanEventArgs args)
    {
        isPanning = true;

        Vector2 deltaPosition0 = args.TrackedFingers[0].deltaPosition;
        Vector2 deltaPosition1 = args.TrackedFingers[1].deltaPosition;

        Vector2 averageDeltaPosition = (deltaPosition0 + deltaPosition1) / 2;

        float horizontalDelta = -(averageDeltaPosition.x / Screen.dpi);
        float verticalDelta = averageDeltaPosition.y / Screen.dpi;

        Vector3 change = Vector3.zero;

        change = new Vector3(verticalDelta, 0, horizontalDelta) * (this._speed * Time.deltaTime);

        Debug.Log("Pan Change: " + change);
        this.transform.position += change;
    }

    public bool IsPanning
    {
        get {return this.isPanning;}
    }

    private void Update()
    {
        if (Input.touchCount != 2)
        {
            isPanning = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GestureManager.Instance.OnPan += this.OnPan;
    }

    void OnDisable()
    {
        GestureManager.Instance.OnPan -= this.OnPan;
    }
}
