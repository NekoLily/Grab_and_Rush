using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformGeneration : MonoBehaviour {
    public GameObject Plateform;
    public Transform generationPoint; // les plateformes ce crées
    public float distanceBetween;

    private float plateformWidth = 1.5f;

	// Use this for initialization
	void Start ()
    {
        plateformWidth = Plateform.GetComponent<BoxCollider2D>().size.x;
        Debug.Log("navi");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
