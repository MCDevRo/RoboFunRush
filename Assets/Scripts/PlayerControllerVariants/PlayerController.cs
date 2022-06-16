  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float horizontalSpeed = 4f;
    public float jumpForce=20;
    public float gravity = -9.81f;
    public float gravityScale = 5;
    float velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Cand lucrezi cum movement asigurate ca folosesti Time.deltaTime!
        //CORECTIE(urmatoarea linie) transform.Translate(Vector3.forward * moveSpeed);  -> e bine dar lipseste indicatia cum sa se miste in spatiu si Time.deltaTime ca sa fie framerate independent.       
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        //float xDirection = Input.GetAxis("Horizontal");
        //float zDirection = Input.GetAxis("Vertical");

        //Vector3 moveDirection = new Vector3(xDirection, 0, 0);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > LevelBoundries.leftBoundry)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < LevelBoundries.rightBoundry)
            {
                transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed);
            }
        }
        //if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow))
        //Debug.Log(this.gameObject.transform.position.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpForce = 5;
            velocity = jumpForce;
        }
        //transform.position += moveDirection * speed;
        transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);

      


    }
}
