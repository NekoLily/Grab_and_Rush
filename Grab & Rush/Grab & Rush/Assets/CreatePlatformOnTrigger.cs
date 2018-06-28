using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlatformOnTrigger : MonoBehaviour {

    public GameObject Spawn;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Spawn.GetComponent<PlatformSpawn>().Spawn();
    }
}
