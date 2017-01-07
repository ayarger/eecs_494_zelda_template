using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EECS494FunBallController : MonoBehaviour {

    public delegate void VoidFunctionCollisionParam(Collision coll);
    public List<VoidFunctionCollisionParam> collision_callbacks = new List<VoidFunctionCollisionParam>();

    // Use this for initialization
    void Start () {
        // Lock ball to the x-y plane.
        // This can be done far easier in the inspector (Rigidbody component).
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
    }

    /* Detect collision and report to listeners */
    private void OnCollisionEnter(Collision collision)
    {
        foreach (VoidFunctionCollisionParam f in collision_callbacks)
            f(collision);
    }
}
