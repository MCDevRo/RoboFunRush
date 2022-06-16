using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    public GameObject colectiblePrefab;
    private Transform playerTarget;
    private int playerOffset;
 

    //New Try
    private Vector3 leftSpawnPos;
    private Vector3 centerSpawnPos;
    private Vector3 rightSpawnPos;

    private Vector3 instantiatePos;
    private Vector3 instantiateObstaclePos;
    private int spawnPos_ID;
    private int obstaclePos_ID;
    // Start is called before the first frame update
    void Start()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        playerOffset = Random.Range(30, 60);
        InvokeRepeating("SpawnCoins", 0.5f, 0.3f);
        InvokeRepeating("SpawnObstacle", 2f, 2f);

    }

    // Update is called once per frame
    void Update()
    {
         
        leftSpawnPos = new Vector3(-1.6f, 0.2f, playerTarget.position.z + playerOffset);
        centerSpawnPos = new Vector3(0, 0.2f, playerTarget.position.z + playerOffset);
        rightSpawnPos = new Vector3(1.6f, 0.2f, playerTarget.position.z + playerOffset);

        
    }

    void SpawnCoins()
    {
        spawnPos_ID = Random.Range(0,3);

        switch (spawnPos_ID)
        {
            case 0:
                instantiatePos = leftSpawnPos;
                break;
            case 2:
                instantiatePos = centerSpawnPos;
                break;
            default:
                instantiatePos = rightSpawnPos;
                break;
        }

        Instantiate(colectiblePrefab, instantiatePos, transform.rotation);
        /*int coresToSpawn = 10;
        for(int i = 0; i < coresToSpawn; i++)
        {

        
            

        }*/
    }

    void SpawnObstacle()
    {
        int rand = Random.Range(0, obstaclePrefab.Length);
        Vector3[] positionArray = new[] { leftSpawnPos, centerSpawnPos, rightSpawnPos };
        obstaclePos_ID = Random.Range(0, positionArray.Length);
        Instantiate(obstaclePrefab[rand], positionArray[obstaclePos_ID], transform.rotation);


    }
}
