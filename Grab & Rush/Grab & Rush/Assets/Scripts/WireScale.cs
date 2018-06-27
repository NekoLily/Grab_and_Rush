using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireScale : MonoBehaviour {

    public GameObject pick; //Objet reference

    void Update()
    {
        Vector2 diff = transform.position - pick.transform.position;
        float angle = Vector2.Angle(Vector2.right, diff.normalized);

        angle = (diff.y < 0) ? angle = 360 - angle : angle;
        transform.localEulerAngles = new Vector3(0, 0, angle);
        transform.localScale = new Vector3(diff.magnitude/2.5f, transform.localScale.y);
    }
}
