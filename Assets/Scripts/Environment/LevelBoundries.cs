using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundries : MonoBehaviour
{
    public static float leftBoundry = -2.3f;
    public static float rightBoundry = 2.3f;
    public float internalLeft;
    public float internalRight;

    // Update is called once per frame
    void Update()
    {
        internalLeft = leftBoundry;
        internalRight = rightBoundry;
    }
}
