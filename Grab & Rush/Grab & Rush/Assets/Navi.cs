using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navi : MonoBehaviour {


    public float speed = 20f;
    public float jumpForce = 200.0f;
    public LayerMask groundLayer;


    // Use this for initialization
    void Start()
    {
    }


    private void Update()
    {
        if (Input.anyKeyDown);
            
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //RaycastHit2D hit = Physics2D.Linecast(transform.position, transform.position - (transform.up * 1.2f), groundLayer);
        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
           
        }
        float h = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed * h, GetComponent<Rigidbody2D>().velocity.y);
      
        if (Input.GetKey(KeyCode.LeftArrow) && transform.localScale.x > 0 || Input.GetKey(KeyCode.RightArrow) && transform.localScale.x < 0)
        {
            Vector2 pos = transform.localScale;
            pos.x *= -1;
            transform.localScale = pos;
        }
    }
}
