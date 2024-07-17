using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadReceiver : MonoBehaviour
{
    public void OnSpread(object sender, SpreadEventArgs args)
    {

    }

    private void Start()
    {
        GestureManager.Instance.OnSpread += this.OnSpread;
    }

    private void OnDisable()
    {
        GestureManager.Instance.OnSpread -= this.OnSpread;
    }

}
