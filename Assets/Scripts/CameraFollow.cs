using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform cameraTarget;
    private Vector3 cameraOffset;
    private Vector3 cameraMove;

    private float transition = 0.0f;
    private float animationLength = 2.0f;
    private Vector3 animationOffset = new Vector3(0, 5, 5);

    // Start is called before the first frame update
    void Start()
    {
        cameraTarget = GameObject.FindGameObjectWithTag("Player").transform;
        cameraOffset = transform.position - cameraTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        cameraMove = cameraTarget.position + cameraOffset;
        // X
        cameraMove.x = 0;
        // Y
        cameraMove.y = Mathf.Clamp(cameraMove.y, 3, 5);

        if(transition > 1f)
        {
            transform.position = cameraMove;
        }
        else
        {
            //Animation at the start of the game
            transform.position = Vector3.Lerp(cameraMove + animationOffset, cameraMove, transition);
            transition += Time.deltaTime * 1 / animationLength;
            transform.LookAt(cameraTarget.position + Vector3.up);
        }
        
        /*if (cameraTarget)
        {
            transform.position = Vector3.Lerp(transform.position, cameraTarget.position + cameraOffset, 0.1f);
        }*/
    }
}
