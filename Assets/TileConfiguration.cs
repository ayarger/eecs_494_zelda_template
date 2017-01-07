using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileConfiguration : MonoBehaviour {
    public static TileConfiguration _instance;

    /* Inspector Tunables */
    public List<TileType> _tile_types;

    // Use this for initialization
    void Start () {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
            _instance = this;
    }
    
    // Update is called once per frame
    void Update () {
        
    }

    public static TileType GetTileType(int x, int y)
    {
        foreach(TileType t in _instance._tile_types)
        {
            if (t.x_coord_in_map_sprites_texture == x
                && t.y_coord_in_map_sprites_texture == y)
                return t;
        }

        Debug.LogError("[ERROR] Failed to find tile type at x=" + x.ToString() + " y=" + y.ToString());
        return null;
    }
}

[System.Serializable]
public class TileType
{
    public int x_coord_in_map_sprites_texture;
    public int y_coord_in_map_sprites_texture;

    public List<string> tile_type_metadata = new List<string>();
}