using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerGetPlayer : MonoBehaviour {

    public GameObject Player;
    private void OnTriggerEnter2D(Collider2D PlayerCollider)
    {
        
        Player = PlayerCollider.gameObject;
        Player.GetComponent<PlayerController>().enabled = false;
        Player.GetComponent<Rigidbody2D>().simulated = false;
    }

    private void Update()
    {
        if(Player != null)
        {
            Player.GetComponent<Transform>().position = this.gameObject.GetComponent<Transform>().position;
        }
    }
}
