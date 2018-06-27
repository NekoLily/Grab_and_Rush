using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour {

    public GameObject Cabin, Wire, Grabber; //Les différentes parties de la machine
    public CircleCollider2D Trigger;
    public GameManager GM; //GameManager
    public float x, y, GrabberYInit; //input x, input y, Distance initiale du DistanceJoint2D
    public bool down, up, isdown, isup; //Baisse, Monte, Est en bas, Est en haut
    public Rigidbody2D CabinRigidBody; //RigidBody de la cabine, sert au deplacement lateral
	// Use this for initialization
	void Start () {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        CabinRigidBody = Cabin.GetComponent<Rigidbody2D>();
        GrabberYInit = Grabber.GetComponent<DistanceJoint2D>().distance;
        isup = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (GM.GameState == Enum.GameState.GamePhaseP1Run || GM.GameState == Enum.GameState.GamePhaseP2Run) //Si phase de jeu
        {
            InputManager(); //Attribuer les input
            Move(x, down, up); //Bouger
        }
            
	}


    void InputManager() //Determine les input en fonction de qui controle
    {
        switch (GM.GameState)
        {
            case Enum.GameState.GamePhaseP1Run:
                x = Input.GetAxis("HorizontalP2");
                y = Input.GetAxis("VerticalP2");
                if (y > 0)
                    up = true;
                else if (y < 0)
                    down = true;
                else
                {
                    up = false;
                    down = false;
                }
                break;
            case Enum.GameState.GamePhaseP2Run:
                x = Input.GetAxis("HorizontalP1");
                y = Input.GetAxis("VerticalP1");
                if (y > 0)
                    up = true;
                else if (y < 0)
                    down = true;
                else
                {
                    up = false;
                    down = false;
                }
                break;
            default:
                
                break;
        }
    }

    void Move(float x, bool down, bool up)
    {
     
        if (down && isup)
        {
            StartCoroutine(GoDown());
        }
        else if (up && isdown)
        {
            StartCoroutine(GoUp());
        }
        else if (Mathf.Abs(x) > 0.7)
        {
            Debug.Log("Should Move");
            CabinRigidBody.AddForce(new Vector2(x * 30, 0f));
        }
        else
        {
            CabinRigidBody.velocity = Vector3.zero;
            CabinRigidBody.angularVelocity = 0f;
        }
    }


    IEnumerator GoDown()
    {
        if(Trigger.gameObject.GetComponent<OnTriggerGetPlayer>().Player == null)
        {
            Trigger.enabled = true;
            while (Grabber.GetComponent<DistanceJoint2D>().distance <= GrabberYInit + 2.5f)
            {

                Grabber.GetComponent<DistanceJoint2D>().distance += 0.02f;
                yield return new WaitForSeconds(0.01f);

            }
            isdown = true;
            isup = false;
            yield return new WaitForSeconds(1f);
            Trigger.enabled = false;

        }
        else
        {
            Trigger.gameObject.GetComponent<OnTriggerGetPlayer>().Player.GetComponent<PlayerController>().enabled = true;
            Trigger.gameObject.GetComponent<OnTriggerGetPlayer>().Player.GetComponent<Rigidbody2D>().simulated = true;
            Trigger.gameObject.GetComponent<OnTriggerGetPlayer>().Player = null;

        }
        //StopCoroutine(GoDown());
    }

    IEnumerator GoUp()
    {
        while (Grabber.GetComponent<DistanceJoint2D>().distance >= GrabberYInit)
        {

            Grabber.GetComponent<DistanceJoint2D>().distance -= 0.02f;
            yield return new WaitForSeconds(0.01f);
        }
        isup = true;
        isdown = false;
        //StopCoroutine(GoUp());
    }
}
