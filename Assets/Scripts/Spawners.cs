using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawners : MonoBehaviour
{
    [Header("Array of GameObjects")]
    public GameObject[] Obstacles;

    [Header("Position Of Spawners")]
    public Transform LeftSpawner;    
    public Transform RightSpawner;       

    [Header("Spawn Offset")]    
    public float RandomYOffsetMinimum = 0f;    
    public float RandomYOffsetMaximum = 6f;      

    [Header("Timer Delay")]   
    [SerializeField] private float spawnDelay;
    private int randomIndex;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawns", 3, spawnDelay);
    }

    void Spawns()
    {   
        //random variables   
        int randomChance = Random.Range(0,Obstacles.Length);
        float randomSpawner = Random.value;
        float randomYOffset = Random.Range(RandomYOffsetMinimum,RandomYOffsetMaximum);           

        //creating the objects here
        if(randomSpawner > 0.5f)
        {
           Instantiate(Obstacles[randomChance], new Vector3(LeftSpawner.position.x, randomYOffset, LeftSpawner.position.z) ,LeftSpawner.rotation);
        }
        else
        {
           Instantiate(Obstacles[randomChance], new Vector3(RightSpawner.position.x, randomYOffset, RightSpawner.position.z) ,RightSpawner.rotation);      
        }    
    }

}