using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceFaceDetector : MonoBehaviour
{
    private Rigidbody rb;
    private bool isRolling;
    private float rollCheckDelay = 2.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isRolling = false;
    }

    void Update()
    {
        if (isRolling && rb.velocity.sqrMagnitude <= 0.1f)
        {
            isRolling = false;
            Invoke("CheckTopFace", rollCheckDelay);
        }
    }

    void CheckTopFace()
    {
        BoxCollider[] colliders = GetComponentsInChildren<BoxCollider>();
        BoxCollider highestCollider = null;
        float highestY = float.MinValue;

        foreach (BoxCollider col in colliders)
        {
            float faceY = col.bounds.center.y + col.bounds.extents.y;
            if (faceY > highestY)
            {
                highestY = faceY;
                highestCollider = col;
            }
        }

        if (highestCollider != null)
        {
            Debug.Log("Top Face: " + highestCollider.name);
            //make highestCollider into an int value for computations when called
        }
    }

    public void StartRolling()
    {
        isRolling = true;
    }
}
