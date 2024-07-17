using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotateReceiver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GestureManager.Instance.OnRotate += this.OnRotate;
    }

    private void OnDisable()
    {
        GestureManager.Instance.OnRotate -= this.OnRotate;
    }

    public void OnRotate(object sendder, RotateEventArgs args)
    {
        Debug.Log("OnRotate Called");
    }
}
