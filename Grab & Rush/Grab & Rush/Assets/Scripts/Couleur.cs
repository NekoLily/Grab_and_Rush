using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Couleur : MonoBehaviour {

    public Color[] playerColors = new Color[10];
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void InitBall()
    {
        Image img = t.GetComponent<Image>();
        img.color = SaveManager.Instance.IsColorOwned(i)
            ? Manager.Instance.playerColors[currentIndex]
            : Colors.Lerp(Manager.Instance.playerColors[currentIndex], new Color(0,0,0,1),0.25f);
    }
}
