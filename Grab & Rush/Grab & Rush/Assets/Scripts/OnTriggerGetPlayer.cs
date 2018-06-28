using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerGetPlayer : MonoBehaviour {

    public GameObject Player;
    public GrabController GC;
    private void OnTriggerEnter2D(Collider2D PlayerCollider)
    {
        
        Player = PlayerCollider.gameObject;
        Player.GetComponent<PlayerController>().enabled = false;
        Player.GetComponent<Rigidbody2D>().simulated = false;
    }

    private void Update()
    {
        GC = GameObject.FindGameObjectWithTag("Machine").GetComponent<GrabController>();
        if(Player != null)
        {
            GC.isup = true;
            Player.GetComponent<Transform>().position = this.gameObject.GetComponent<Transform>().position;
        }
    }
}
