using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformScript : MonoBehaviour {
    public float speed = 5f;

    GameManager GM;
    // Use this for initialization
    void Start () {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

    // Update is called once per frame
    void Update()
    {
        if (GM.GameState == Enum.GameState.GamePhaseP1Run || GM.GameState == Enum.GameState.GamePhaseP2Run)
         transform.Translate(- speed * Time.deltaTime, 0, 0);
    }

}
