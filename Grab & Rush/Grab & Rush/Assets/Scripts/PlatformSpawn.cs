using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour {

    public GameObject PlatformPrefab;
    public float spawnRate = 3f;
    public int SizePlatforms = 5;
    public float PlatformMax = 2.5f;
    public float PlatformMin = 1.5f;

    GameObject[] platforms;
    int currentPlatforms;

	// Use this for initialization
	void Start ()
    {
        platforms = new GameObject[SizePlatforms];
        for(int i=0; i< SizePlatforms; i ++)
        {
            platforms[i] = (GameObject)Instantiate(PlatformPrefab, new Vector3(-15.0f, -25.0f, 0), Quaternion.identity);
        }
        StartCoroutine("SpawnLoop");
	}
	
    IEnumerator SpawnLoop()
    {
        while (true)
        {
            Vector3 pos = transform.position;
            pos.y = Random.Range(PlatformMax,PlatformMin);
            platforms[currentPlatforms].transform.position = pos;
        }
    }

	// Update is called once per frame
	void Update ()
    {
		
	}
}
