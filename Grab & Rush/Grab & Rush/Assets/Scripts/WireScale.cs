using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireScale : MonoBehaviour {

    public GameObject pick; //Objet reference

    void Update()
    {
        Vector2 diff = transform.position - new Vector3(pick.transform.position.x + pick.GetComponent<DistanceJoint2D>().anchor.x, pick.transform.position.y + pick.GetComponent<DistanceJoint2D>().anchor.y);
        float angle = Vector2.Angle(Vector2.right, diff.normalized);

        angle = (diff.y < 0) ? angle = 360 - angle : angle;
        transform.localEulerAngles = new Vector3(0, 0, angle+90f);
        transform.localScale = new Vector3(transform.localScale.x, -diff.magnitude/2.5f + diff.magnitude / 16f);
    }
}
