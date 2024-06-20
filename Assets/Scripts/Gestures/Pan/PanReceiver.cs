using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanReceiver : MonoBehaviour
{
    private float _speed = 50.0f;


    public void OnPan(object sender, PanEventArgs args)
    {
        // Check if there are two tracked fingers
        if (args.TrackedFingers.Length >= 2)
        {
            // Calculate the movement vector based on the difference between the two finger positions
            Vector2 moveVector = args.TrackedFingers[1].position - args.TrackedFingers[0].position;

            // Normalize the movement vector and scale it by the speed
            Vector3 moveDirection = new Vector3(moveVector.x, 0, moveVector.y).normalized * _speed;

            // Apply the movement to the camera's position
            transform.Translate(moveDirection, Space.World);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
