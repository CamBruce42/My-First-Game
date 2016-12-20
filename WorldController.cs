using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class WorldController : MonoBehaviour {

    public static WorldController Instance { get; protected set; }

    public Sprite florSprite, waterSprite;

    public World world { get; protected set; }
	// Use this for initialization
	void Start () {
        if(Instance!= null)
        {
            Debug.LogError("There should never be 2 controllers");
        }
        Instance = this;

        //Create a world with empty tiles
        world = new World();

       
        //Create GameObject fore each of our tiles to see
        for (int x = 0; x < world.Width; x++)
        {
            for(int y = 0; y < world.Height; y++)
            {
                Tile tile_data = world.GetTileAt(x, y);
                GameObject tile_go = new GameObject();

                tile_go.name = "Tile_ " + x + "_" + y;
                tile_go.transform.position = new Vector3(tile_data.x, tile_data.y, 0);
                tile_go.transform.SetParent(this.transform, true);
                //add a sprite renderer but dont set sprite
                tile_go.AddComponent<SpriteRenderer>();

                tile_data.RegisterTileTypeChangedCallback((tile) => { OnTileTypeChanged(tile, tile_go); } );
 
            }
        }
       //world.RandomizeTiles();
       world.RandomizeTiles();
       world.insertBuilding(2,2);

    }

   

	// Update is called once per frame
	void Update () {
       
	}

    
    void OnTileTypeChanged(Tile tile_data, GameObject tile_go)
    {       
        if (tile_data.Type == Tile.TileType.Grass)
        {       
            tile_go.GetComponent<SpriteRenderer>().sprite = florSprite;
        }
        else if(tile_data.Type == Tile.TileType.Dirt)
        {
            tile_go.GetComponent<SpriteRenderer>().sprite = null;
        }
        else if(tile_data.Type == Tile.TileType.Water)
        {
            tile_go.GetComponent<SpriteRenderer>().sprite = waterSprite;
        }
        else
        {
            Debug.LogError("OnTileTypeChanged - Unrecognized tile type.");
        }
    }
    public Tile GetTileAtWorldCoord(Vector3 coord)
    {
        int x = Mathf.FloorToInt(coord.x);
        int y = Mathf.FloorToInt(coord.y);

        return world.GetTileAt(x,y);
    }
}
