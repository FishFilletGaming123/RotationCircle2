using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float rotationSpeed;
    private bool isClockWise;

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           isClockWise = !isClockWise;
        }        
        Rotation();
    }

    public void Rotation()
    {
        if (isClockWise)
        {
           transform.Rotate(0,0,1 * rotationSpeed * Time.deltaTime);
        }
        else 
        {
           transform.Rotate(0,0,-1 * rotationSpeed * Time.deltaTime);            
        }           
    }
}
