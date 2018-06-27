using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerGetPlayer : MonoBehaviour {

    public GameObject Player;
    private void OnTriggerEnter(Collider PlayerCollider)
    {
        Player = PlayerCollider.gameObject;
        Player.GetComponent<PlayerController>().enabled = false;
    }

    private void Update()
    {
        if(Player != null)
        {
            Player.GetComponent<Transform>().position = this.gameObject.GetComponent<Transform>().position;
        }
    }
}
