using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float maxSpeed = 50f;
    public float jumpPower = 180f;
    public float Offset_Y;
    private int Jump_Number = 2;

    void Update()
    {
        RaycastHit2D Hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + Offset_Y), transform.position + (Vector3.down * 0.75f));
        Debug.DrawLine(new Vector2(transform.position.x, transform.position.y + Offset_Y), transform.position + (Vector3.down * 0.75f), Color.green);// TMP
        if (Hit.collider != null)
        {
            Debug.Log(Hit.collider.name);
            if (Hit.collider.tag == "Ground")
            {
                Jump_Number = 2;
            }
        }
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

        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (jump)
        {
            Jump_Number--;
            if (Jump_Number > 0)
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
        }
    }
}
