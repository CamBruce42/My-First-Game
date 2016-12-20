using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World {

    Tile[,] tiles;
    int width;
  

    public int Width
    {
        get
        {
            return width;
        }
       
    }
    public int Height
    {
        get
        {
            return height;
        }
    }

    int height;


    public World(int width = 50, int height = 50)//size of the world
    {
        this.width = width;
        this.height = height;

        tiles = new Tile[width, height];

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                tiles[x, y] = new Tile(this, x, y);
            }
        }
        Debug.Log("World created with " + (width * height) + " tiles");
    }

    public void RandomizeTiles()
    {
        Debug.Log("Randomize Tiles");
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if(Random.Range(0,2) == 0)
                 {
                     tiles[x, y].Type = Tile.TileType.Grass;
                    
                }
                else
                 {
                     tiles[x, y].Type = Tile.TileType.Dirt;
                 }
              
            }
        }
    }
    public void insertBuilding(int startX, int startY)
    {
        int buildingLength = 10;
        int buildingWidth = 8;
        


        for (int x = startX;  x <= startX + buildingWidth; x++)
        {
            for (int y = startY;  y <= startY + buildingLength; y++)
            {
                if(x == startX || x == (startX + buildingWidth)){
                     tiles[x, y].Type = Tile.TileType.Water;//testing
                     Debug.Log("Doing the x's");
                 }
                if(y == startY || y == (startY + buildingLength))
                 {
                     tiles[x, y].Type = Tile.TileType.Water;//testing
                     Debug.Log("Doing the y's");
                 }
               
            }
        }
    }

    public Tile GetTileAt(int x, int y) {
        if(x > width || x < 0 || y > height || y < 0){
            Debug.LogError("Tile ("+x+","+y+") is out of range. ");
            return null;
        }
        return tiles[x, y];

    }     
   
}
