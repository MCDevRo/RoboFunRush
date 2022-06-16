using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //Array that can store the LevelBlocks for endless generation
    public GameObject[] levelBlock;
    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float blockLength = 50f;
    private int blocksOnScreen = 6;
    private float safeZone = 30f;
    private List<GameObject> activeBlocks;
    private int blockVariant;
    //The exact distance of each block needed for position spawning
    //private int zPos = 0;
    //Just a variable to index with a value each Levelblock in the array 
    //private int blockNum;
    //The statement which allows the LevelBlock generation to start
    //private bool creatingBlock = false;
    private void Start()
    {
        activeBlocks = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < blocksOnScreen; i++)
        {
            SpawnBlock();            
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - safeZone > (spawnZ - blocksOnScreen * blockLength))
        {
            SpawnBlock();
            DeleteBlock();
        }
        //Checking the statement for Level to start generating blocks
        /*if (creatingBlock == false)
        {
            creatingBlock = true;
            StartCoroutine(GenerateLevelBlock());
            
        }*/

    }

    void SpawnBlock(int prefabIndex  = -1)
    {
        GameObject newBlock;
         blockVariant = Random.Range(0, 3);
        newBlock = Instantiate(levelBlock[blockVariant] as GameObject);
        newBlock.transform.SetParent(transform);
        newBlock.transform.position = Vector3.forward * spawnZ;
        spawnZ += blockLength;
        activeBlocks.Add(newBlock);
        
    }
    void DeleteBlock()
    {
        Destroy(activeBlocks[0]);
        activeBlocks.RemoveAt(0);

    }
    /*IEnumerator GenerateLevelBlock()
    {
        //Corouting logic for spawning LevelBlocks
        blockNum = Random.Range(0, 3);
        GameObject newBlock;
        newBlock = Instantiate(levelBlock[blockNum], new Vector3(0, 0, zPos), Quaternion.identity);
            zPos += 50;
        yield return new WaitForSeconds(2);
        creatingBlock = false;
    }*/
 

}
