/* A component controlling the behavior of the funnest ball around */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EECS494FunBall : MonoBehaviour {

    // Use this for initialization
    void Start () {
        // Lock ball to the x-y plane.
        // This can be done far easier in the inspector (Rigidbody component).
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
    }
    
    // Update is called once per frame
    void Update () {
        ProcessScale();
    }

    /* Detect collision and increase size of ball */
    private void OnCollisionEnter(Collision collision)
    {
        transform.localScale = Vector3.one * 1.25f;
    }

    /* Ensure the ball return to normal size over time */
    void ProcessScale()
    {
        if (transform.localScale.x > 1.0f)
        {
            transform.localScale -= Vector3.one * 0.01f;
        }
        else
            transform.localScale = Vector3.one;
    }
}
