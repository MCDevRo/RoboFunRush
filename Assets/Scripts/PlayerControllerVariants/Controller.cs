using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public enum SIDE { Left,Mid,Right}
public class Controller : MonoBehaviour
{
    public SIDE m_Side = SIDE.Mid;
    float newPosX = 0f;
    [HideInInspector]
    public bool swipeLeft, swipeRight, swipeUp, swipeDown;
    public float xValue = 1.6f;
    private CharacterController m_Char;
    private Animator playerAnim;
    private float xTransition;
    public float dodgeSpeed;
    private float jumpPower = 7f;
    private float yVelocity;
    public bool inJump, inRoll;
    private bool groundedPlayer;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.8f;
    private Vector3 playerVelocity;

    private float collHeight;
    private float collCenterY;


    // Start is called before the first frame update
    void Start()
    {
        m_Char = GetComponent<CharacterController>();
        collHeight = m_Char.height;
        collCenterY = m_Char.center.y;
        playerAnim = GetComponent<Animator>();
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = m_Char.isGrounded;
        swipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        swipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        swipeUp = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space);
        swipeDown = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);
        /*if(groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }*/
        Vector3 moveVector = new Vector3(xTransition - transform.position.x, yVelocity * Time.deltaTime, 10f * Time.deltaTime);
        xTransition = Mathf.Lerp(xTransition, newPosX, Time.deltaTime * dodgeSpeed);
        m_Char.Move(moveVector);
        
        Jump();
        Roll();
        //m_Char.Move(playerVelocity * Time.deltaTime);

        if (swipeLeft)
        {
            if(m_Side == SIDE.Mid)
            {
                newPosX = -xValue;
                m_Side = SIDE.Left;
                playerAnim.Play("DodgeLeft");
            }
            else if(m_Side == SIDE.Right)
            {
                newPosX = 0;
                m_Side = SIDE.Mid;
                playerAnim.Play("DodgeLeft");
            }
            FindObjectOfType<AudioManager>().Play("Move");
        }
        else if (swipeRight)
        {
            if (m_Side == SIDE.Mid)
            {
                newPosX = xValue;
                m_Side = SIDE.Right;
                playerAnim.Play("DodgeRight");
            }
            else if (m_Side == SIDE.Left)
            {
                newPosX = 0;
                m_Side = SIDE.Mid;
                playerAnim.Play("DodgeRight");
            }
            FindObjectOfType<AudioManager>().Play("Move");

        }


    }
    public void Jump()
    {
        /*if(groundedPlayer && swipeUp)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            playerAnim.Play("Jump");
        }
        playerVelocity.y += gravityValue * Time.deltaTime;*/
        if (groundedPlayer)
        {
            /*if (playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Fall"))
            {
                playerAnim.Play("Land");
                inJump = false;

            }*/
            if (swipeUp)
            {
                yVelocity = jumpPower;
                playerAnim.CrossFadeInFixedTime("Jump", 0.1f);
                inJump = true;
            }
            
        }
        else
        {
            yVelocity -= jumpPower * 2 * Time.deltaTime;           
            if (m_Char.velocity.y < -0.1)
            {
                inJump = false;
            }
            //playerAnim.Play("Fall");
            
        }
        
    }
    internal float RollCounter;
    public void Roll()
    {
        RollCounter -= Time.deltaTime;
        if(RollCounter <= 0)
        {
            RollCounter = 0f;
            m_Char.center = new Vector3(0, collCenterY, 0);
            m_Char.height = collHeight;
            inRoll = false;
        }
        if (swipeDown)
        {
            RollCounter = 0.2f;
            yVelocity -= 10f;
            m_Char.center = new Vector3(0, collCenterY/2f, 0);
            m_Char.height = collHeight/2f;
            playerAnim.Play("Slide");
            inRoll = true;
            inJump = false;
        }
    }
}
