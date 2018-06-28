using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            GameObject.Find("GameManager").GetComponent<GameManager>().RunnerWin = false;
            GameObject.Find("GameManager").GetComponent<GameManager>().GameState = Enum.GameState.EndRound;
        }
    }
}
