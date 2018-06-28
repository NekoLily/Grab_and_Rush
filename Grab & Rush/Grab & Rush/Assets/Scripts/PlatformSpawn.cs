using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour {

    public GameObject[] PlatformPrefab;
    public float spawnMax = 2.5f;
    public float spawnMin = 0.5f;
    public float speed = 5f;
    

    //GameObject[] platforms;
    //int currentPlatforms;

    // Use this for initialization
    void Start ()
    {
       Spawn();
        
	}
 
    void Spawn()
    {
        Instantiate(PlatformPrefab[Random.Range(0, PlatformPrefab.GetLength(0))], transform.position, Quaternion.identity);
        
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));

    }

    // Update is called once per frame
   
}
