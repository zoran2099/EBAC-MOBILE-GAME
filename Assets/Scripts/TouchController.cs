using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{


    [SerializeField]
    private Vector2 pastPosition;    
    public float Acceleration;

    
    // Update is called once per frame
    void Update()
    {
    
        if (Input.GetMouseButton(0))
        {
            Move(Speed(pastPosition.x, Input.mousePosition.x, Acceleration));
        }
        pastPosition = Input.mousePosition;

    }

    private void Move(float speed)
    {
        transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * speed;
    }

    private float Speed(float currentPosition, float targetPosition, float acceleration)
    {
        return (targetPosition - currentPosition) * acceleration;
    }
}
