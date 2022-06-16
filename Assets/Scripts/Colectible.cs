using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colectible : MonoBehaviour
{
    //Am facut script separat pentru rotate coin asta sa il folosim si la generare obstacle
    public float rotateSpeed = 90f;
    private Transform playerTarget;
    private Transform colectibleTransform;
    private int playerOffset = 10;
    
    


    // Start is called before the first frame update
    void Start()
    {
        //playerController = GetComponent<Controller>();
        colectibleTransform = GetComponent<Transform>();
        Vector3 pos = transform.position;
        pos.y = 0.7f;
        transform.position = pos;
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        //On trigger distrugere coin
        if (gameObject.CompareTag("Coin"))
        {
            FindObjectOfType<AudioManager>().Play("Coin");

            ScoreManager.instance.AddPoint();
            Destroy(gameObject);
        }
        //On trigger distrugere player 
        if (gameObject.CompareTag("Obstacle"))
        {
            FindObjectOfType<AudioManager>().Play("Death");

            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().Play("Death");
            GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().enabled = false;
            //Destroy(other.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("Coin"))
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
        

        if(playerTarget.transform.position.z > colectibleTransform.transform.position.z + playerOffset)
        {
            Destroy(gameObject);
        }
    }
}
