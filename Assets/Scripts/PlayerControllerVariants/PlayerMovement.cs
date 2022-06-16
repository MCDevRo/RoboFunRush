using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float forwardSpeed = 10f;
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public float timeRemaining = 10;
    private float increseSpeed = 1.1f;

    void Start()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(moveHorizontal * moveSpeed, rb.velocity.y, forwardSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
        TimeCounter();
    }

    void TimeCounter()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = 10;
            forwardSpeed = forwardSpeed * increseSpeed;
        }
    }
}
