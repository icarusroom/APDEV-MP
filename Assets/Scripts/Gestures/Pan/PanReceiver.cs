using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanReceiver : MonoBehaviour
{
    private float _speed = 50.0f;


    public void OnPan(object sender, PanEventArgs args)
    {
        Vector2 deltaPosition0 = args.TrackedFingers[0].deltaPosition;
        Vector2 deltaPosition1 = args.TrackedFingers[1].deltaPosition;

        Vector2 averagePosisition = (deltaPosition0 + deltaPosition1) / 2;
        averagePosisition = averagePosisition / Screen.dpi;

        Vector3 change = averagePosisition * (this._speed * Time.deltaTime);
        this.transform.position += change;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
