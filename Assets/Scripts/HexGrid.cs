using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    public GameObject hexPrefab;
    public GameObject gamePiecePrefab;  // Assign a prefab for the GamePiece
    public int width = 12;
    public int height = 12;
    public float xOffset = 0.882f;
    public float yOffset = 0.764f;
    private GameObject[,] grid;
    
    void Awake()
    {
        grid = new GameObject[width, height];
    }

    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        Vector2 gridTotalSize = new Vector2((width * xOffset) + (xOffset / 2), height * yOffset);
        Vector2 centerOffset = new Vector2(gridTotalSize.x / 2, gridTotalSize.y / 2);

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
                hex_go.GetComponent<Hex>().SetCoordinates(new Vector2Int(x, y));

                grid[x, y] = hex_go;

            }
        }
    }

    public void HighlightHexes(List<Vector3Int> hexes, bool highlight)
    {
        GameObject hextToHighlight = null;
        foreach (Vector3Int hex in hexes)
        {
            hextToHighlight = GetHexAt(hex);
            if (hextToHighlight != null)
            {
                SpriteRenderer renderer = hextToHighlight.GetComponent<SpriteRenderer>();
                if (highlight)
                    renderer.color = Color.yellow; // Change this color to your preferred highlight color
                else
                    renderer.color = Color.white; // Original color
            }
        }
    }

    public GameObject GetHexAt(Vector3Int hexCoords)
    {
        if( hexCoords.x < 0 || hexCoords.x >= width || hexCoords.y < 0 || hexCoords.y >= height)
        {
            return null;
        }
        return this.grid[hexCoords.x, hexCoords.y];
    }
}