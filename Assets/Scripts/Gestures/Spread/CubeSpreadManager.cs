using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpreadManager : MonoBehaviour, ISpreadable
{
    [SerializeField]
    private float _speedResize = 3.0f;

    public void OnSpread(SpreadEventArgs args)
    {
      
        float scale = (args.DistanceDelta) * (this._speedResize * Time.deltaTime);
        this.transform.localScale += new Vector3(scale, scale, scale);
    }

    public void OnPinch(SpreadEventArgs args)
    {
        float scale = (args.DistanceDelta) * (this._speedResize * Time.deltaTime);
        this.transform.localScale -= new Vector3(scale, scale, scale);
    }

}
