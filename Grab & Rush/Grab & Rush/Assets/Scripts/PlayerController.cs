using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 50f;
    public float jumpPower = 180f;
    private CapsuleCollider2D m_capsulecollier2D;
    private Rigidbody2D m_rigidbody2D;
    private int Jump_Number = 0;

    // Use this for initialization
    void Awake()
    {
        m_capsulecollier2D = GetComponent<CapsuleCollider2D>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start ()
    {
	    	
	}

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        bool jump = Input.GetButtonDown("Jump");
        Move(x, jump);
    }

    void Move(float move, bool jump)
    {
        if (Mathf.Abs(move) > 0)
        {
            Quaternion rot = transform.rotation;
            transform.rotation = Quaternion.Euler(rot.x, Mathf.Sign(move) == 1 ? 0 : 180, rot.z);
        }

        m_rigidbody2D.velocity = new Vector2(move * maxSpeed, m_rigidbody2D.velocity.y);

        if (jump)
        {
            Jump_Number--;
            if (Jump_Number > 0)
                m_rigidbody2D.AddForce(Vector2.up * jumpPower);
        }
    }
}
