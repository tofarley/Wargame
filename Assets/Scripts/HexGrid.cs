using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using Unity.Mathematics;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    public GameObject hexPrefab;
    public GameObject gamePiecePrefab;  // Assign a prefab for the GamePiece
    public int width = 10;
    public int height = 10;

    GameObject[,] hexGrid;

    
    public float xOffset = 0.882f;
    public float yOffset = 0.764f;

    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        Vector2 gridTotalSize = new Vector2((width * xOffset) + (xOffset / 2), height * yOffset);
        Vector2 centerOffset = new Vector2(gridTotalSize.x / 2, gridTotalSize.y / 2);

        hexGrid = new GameObject[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float xPos = x * xOffset - centerOffset.x;
                if (y % 2 == 1)
                {
                    xPos += xOffset / 2f;
                }

                GameObject hex_go = Instantiate(hexPrefab, new Vector3(xPos, y * yOffset - centerOffset.y, 0), Quaternion.identity);
                hex_go.name = "Hex_" + x + "_" + y;
                hex_go.transform.parent = this.transform;

                hexGrid[x,y] = hex_go;
                // Optionally instantiate and position a game piece on a specific hex
                if (x == 5 && y == 5)  // Example condition for placing a game piece
                {
                    GameObject gamePiece = Instantiate(gamePiecePrefab);
                    gamePiece.GetComponent<GamePiece>().Initialize(new Vector2Int(x, y), hex_go);

                }
            }
        }
    }

    public void HighlightAdjacentHexes(Vector2Int centerHexCoords, bool highlight)
    {
        Vector2Int[] directions = new Vector2Int[]
        {
        new Vector2Int(+1, 0), new Vector2Int(-1, 0), // Horizontal neighbors for flat-topped
        new Vector2Int(0, +1), new Vector2Int(0, -1), // Vertical neighbors for flat-topped
        new Vector2Int(+1, -1), new Vector2Int(+1, +1) // Diagonal neighbors for flat-topped
        };

        foreach (Vector2Int dir in directions)
        {
            Vector2Int neighborCoords = centerHexCoords + dir;
            GameObject neighborHex = GetHexAt(neighborCoords);

            if (neighborHex != null)
            {
                SpriteRenderer renderer = neighborHex.GetComponent<SpriteRenderer>();
                if (highlight)
                {
                    
                    renderer.color = Color.yellow; // Change this color to your preferred highlight color
                }
                else
                    renderer.color = Color.white; // Original color
            }
        }
    }

    GameObject GetHexAt(Vector2Int hexCoords)
    {
        // Implement retrieval of the hex GameObject from stored hexes
        // This is a placeholder to adapt based on your storage method of hex tiles
        Debug.Log("Returning hex at " + hexCoords.x + " by " + hexCoords.y);
        return this.hexGrid[hexCoords.x, hexCoords.y];
    }
}