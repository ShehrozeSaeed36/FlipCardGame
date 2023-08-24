using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnAngle : MonoBehaviour
{
    [SerializeField] Vector3 rotateAngle;
    [SerializeField] float rotateSpeed;
    void Update()
    {
        transform.Rotate(rotateAngle * rotateSpeed);     
    }
}
