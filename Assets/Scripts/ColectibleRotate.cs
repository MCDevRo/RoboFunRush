using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectibleRotate : MonoBehaviour
{
    public float rotateSpeed = 90f;


    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);

    }
}
