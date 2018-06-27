using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour {
    public float maxPlatforms = 10f;

    public GameObject platform;
    //distance et hauteur;

    public float horizontalMax = -0.2f;
    public float horizontalMin = -3f;
    public float verticalMax = 6f;
    public float verticalMin = -6f;
    public float distanceplatform = 0.2f;

    private Vector2 originPosition;

    public float MaxPlatforms
    {
        get
        {
            return maxPlatforms;
        }

        set
        {
            maxPlatforms = value;
        }
    }

    // Use this for initialization
    void Start()
    {

        originPosition = transform.position;
        Spawn();

    }

    void Spawn()
    {
        for (int i = 0; i <= MaxPlatforms; i++)
        {
            Vector2 randomPosition = originPosition + new Vector2(Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax));
            Instantiate(platform, randomPosition, Quaternion.identity);
            originPosition = randomPosition;
        }
    }

}
