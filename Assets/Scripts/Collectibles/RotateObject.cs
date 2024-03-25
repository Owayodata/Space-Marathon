using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float RotateSpeed = 1f; //defines the rotation speed
    void Update()
    {
        transform.Rotate(0, RotateSpeed, 0, Space.World); //rotates the object in y axis, relative to the game world
    }
}
