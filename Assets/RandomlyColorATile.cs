/* A component that randomly colors a random tile */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomlyColorATile : MonoBehaviour {

    // Use this for initialization
    void Start () {
        print(ShowMapOnCamera.MAP_TILES[0, 0].name);
    }
    
    // Update is called once per frame
    void Update () {
        
    }
}
