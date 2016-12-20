using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Tile {

    public enum TileType { Grass, Dirt, Water, Fertile_Soil };//obviously the tile types

    TileType type = TileType.Grass; //this gives us grass as a default maybe

    Action<Tile> cbTileTypeChanged; 
    

    public TileType Type
    {
        get
        {
            return type;
        }

        set
        {
            //TileType oldType = type; //tthis was used for that explanation before
            type = value;
            if(cbTileTypeChanged != null)//okay so this line had  "&& oldType != type" but it wasn't working fyi.
            {
                cbTileTypeChanged(this);
            }
            
            // Call the callback and let things know we have changed
        }
    }

    LooseObject looseObject;
    InstalledObject installedObject;

    World world;
    public int x { get; protected set; }
    public int y { get; protected set; }
   /* int x;
    public int X
    {
        get
        {
            return x;
        }
    }


    int y;
    public int Y
    {
        get
        {
            return y;
        }

    }He changed this with what was above
    */
    

    public Tile(World world, int x, int y) {
        this.world = world;
        this.x = x;
        this.y = y;
    }

    public void RegisterTileTypeChangedCallback(Action<Tile> callback)
    {
        cbTileTypeChanged += callback;
    }
    public void UnegisterTileTypeChangedCallback(Action<Tile> callback)
    {
        cbTileTypeChanged -= callback;
    }
}
