/* A component that causes a camera to follow a target object */
using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    static public CameraFollow instance; // This is a pseudo-singleton

    /* Inspector Tunables */
    public Transform target_transform; // The object for the camera to follow
    public Vector3 offset = new Vector3(0,1,-10); // Where should the camera be relative to that object.
    public float easingU = 0.05f; // What easing should the camera have getting there?

    /* Private Data */
    private Camera cam;

    void Awake () {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        } else
        {
            instance = this;
        }

        cam = GetComponent<Camera>();

        // Initially position the camera exactly over the target_transform
        transform.position = target_transform.position + offset;
    }
    
    void FixedUpdate () {
        Vector3 p0, p1, p01;

        p0 = transform.position;
        p1 = target_transform.position + offset;

        // Linear Interpolation
        p01 = (1-easingU)*p0 + easingU*p1;
        p01.x = RoundToNearestPixel(p01.x, cam);
        p01.y = RoundToNearestPixel(p01.y, cam);
        transform.position = p01;
    }

    private float RoundToNearestPixel(float unityUnits, Camera viewingCamera)
    {
        float valueInPixels = (Screen.height / (viewingCamera.orthographicSize * 2)) * unityUnits;
        valueInPixels = Mathf.Round(valueInPixels);
        float adjustedUnityUnits = valueInPixels / (Screen.height / (viewingCamera.orthographicSize * 2));
        return adjustedUnityUnits;
    }
}
