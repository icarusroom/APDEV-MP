using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideProperty : MonoBehaviour
{
    [SerializeField] int sideValue;
    // Start is called before the first frame update
    public int SideValue
    {
        get { return this.sideValue; }
        set { this.sideValue = value; }
    }
}
