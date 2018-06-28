using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public void LoadGame()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().LoadScene(2);
    }

    public void LoadMainMenu()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().LoadScene(0);
    }
}
