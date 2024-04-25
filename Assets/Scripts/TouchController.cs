using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{


    [SerializeField]
    private Vector2 pastPosition;    
    public float acceleration;

    
    // Update is called once per frame
    void Update()
    {
    
        if (Input.GetMouseButton(0))
        {
            Move( Input.mousePosition.x - pastPosition.x);
        }
        pastPosition = Input.mousePosition;

    }

    private void Move(float speed)
    {
        transform.position += Vector3.right * Time.deltaTime * speed * acceleration;
    }

   
}
