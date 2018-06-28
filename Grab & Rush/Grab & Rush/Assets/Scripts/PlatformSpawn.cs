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
 
    public void Spawn()
    {
        Instantiate(PlatformPrefab[Random.Range(0, PlatformPrefab.GetLength(0))], new Vector3(Random.Range(transform.position.x-2, transform.position.x+4f), Random.Range(transform.position.y, transform.position.y-2), transform.position.z), Quaternion.identity);
        
        //Invoke("Spawn", Random.Range(spawnMin, spawnMax));

    }

    // Update is called once per frame
   
}
