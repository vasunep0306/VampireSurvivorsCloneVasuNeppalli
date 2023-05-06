using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScrolling : MonoBehaviour
{
    
    public int terrainTileHorizontalCount;
    public int terrainTileVerticalCount;

    Vector2Int currentTitlePosition = new Vector2Int(0,0);
    public Vector2Int playerTilePosition;
    Vector2Int onTileGridPlayerPosition;
    Vector2Int currentTilePlayerPosition;
    public float tileSize = 20f;

    GameObject[,] terrainTiles;

    // field of vision
    public int fieldOfVisionWidth;
    public int fieldOfVisionHeight;


    private Transform playerTransform;

    private void Start()
    {
        UpdateTilesOnScreen();
        playerTransform = GameManager.instance.playerTransform;
    }

    private void Update()
    {
        playerTilePosition.x = (int)(playerTransform.position.x / tileSize);
        playerTilePosition.y = (int)(playerTransform.position.y / tileSize);

        playerTilePosition.x -= playerTransform.position.x < 0 ? 1 : 0;
        playerTilePosition.y -= playerTransform.position.y < 0 ? 1 : 0;

        if (currentTitlePosition != playerTilePosition)
        {
            currentTitlePosition = playerTilePosition;

            onTileGridPlayerPosition.x = CalculatePositionOnAxis(onTileGridPlayerPosition.x, true);
            onTileGridPlayerPosition.y = CalculatePositionOnAxis(onTileGridPlayerPosition.y, false);
            UpdateTilesOnScreen();
        }
    }


    /// <summary>
    /// Updates the position and appearance of the tiles on the screen based on the player's position and field of vision.
    /// </summary>
    private void UpdateTilesOnScreen()
    {

        for(int pov_x = -(fieldOfVisionWidth/2); pov_x <= fieldOfVisionWidth / 2; pov_x++)
        {
            for(int pov_y = -(fieldOfVisionHeight / 2); pov_y <= fieldOfVisionHeight/2; pov_y++)
            {
                int tileToUpdate_x = CalculatePositionOnAxis(playerTilePosition.x + pov_x, true);
                int tileToUpdate_y = CalculatePositionOnAxis(playerTilePosition.y + pov_y, false);

                GameObject tile = terrainTiles[tileToUpdate_x, tileToUpdate_y];
                Vector3 newPosition = CalculatePosition(
                    playerTilePosition.x + pov_x,
                    playerTilePosition.y + pov_y
                    );
                if(newPosition != tile.transform.position)
                {
                    tile.transform.position = newPosition;
                    terrainTiles[tileToUpdate_x, tileToUpdate_y].GetComponent<TerrainTile>().Spawn();
                }
                


            }
        }
    }


    /// <summary>
    /// Calculates the world position of a tile based on its grid coordinates and tile size.
    /// </summary>
    /// <param name="x">The x coordinate of the tile.</param>
    /// <param name="y">The y coordinate of the tile.</param>
    /// <returns>A Vector3 representing the world position of the tile.</returns>
    private Vector3 CalculatePosition(int x, int y)
    {
        return new Vector3(x * tileSize, y * tileSize, 0f); 
    }


    /// <summary>
    /// Calculates the position of a tile on a given axis based on its current value and the terrain tile count.
    /// </summary>
    /// <param name="currentValue">The current value of the tile on the axis.</param>
    /// <param name="horizontal">A boolean indicating whether the axis is horizontal or vertical.</param>
    /// <returns>An integer representing the position of the tile on the axis.</returns>
    private int CalculatePositionOnAxis(float currentValue, bool horizontal)
    {
        if(horizontal)
        {
            if(currentValue >= 0)
            {
                currentValue = currentValue % terrainTileHorizontalCount;
            } 
            else
            {
                currentValue += 1;
                currentValue = terrainTileHorizontalCount-1 + currentValue % terrainTileHorizontalCount;
            }
        } else
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % terrainTileVerticalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = terrainTileVerticalCount-1 + currentValue % terrainTileVerticalCount;
            }
        }
        return (int)currentValue;
    }

    private void Awake()
    {
        terrainTiles = new GameObject[terrainTileHorizontalCount, terrainTileVerticalCount];
    }




    /// <summary>
    /// Adds a game object to the terrain tiles array at a given position.
    /// </summary>
    /// <param name="tileGameObject">The game object to be added.</param>
    /// <param name="tilePosition">The position of the tile in the array.</param>
    public void Add(GameObject tileGameObject, Vector2Int tilePosition)
    {
        terrainTiles[tilePosition.x, tilePosition.y] = tileGameObject;
    }
}
