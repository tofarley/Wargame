using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GamePiece : MonoBehaviour
{
    // Grid coordinates
    public Vector3Int gridPosition;

    // Reference to the SpriteRenderer component
    private SpriteRenderer spriteRenderer;

    private Grid grid;
    private GameManager gameManager;
    
    private bool isSelected = false;

    public bool IsSelected
    {
        get => isSelected;
    }
    
    [SerializeField] private int searchRange = 3;

    //[SerializeField] private Grid grid;

    public Vector3Int hexCoordinates;
    public GameObject currentHexTile;

    // Initialize the GamePiece on a specific hex tile
    public void Initialize(Vector3Int coordinates, GameObject hexTile)
    {
        hexCoordinates = coordinates;
        currentHexTile = hexTile;
        this.transform.position = hexTile.transform.position; // Align the game piece with the hex tile
        transform.Rotate(0, 0, -30);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get the SpriteRenderer component attached to this GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameObject gameObject = GameObject.FindWithTag("GameManager");

        gameManager = gameObject.GetComponent<GameManager>();
        //grid = GetComponent<Grid>();
        //OnMouseDown();
    }



    // Update is called once per frame
    void Update()
    {

    }

    // Method to set the sprite of the GamePiece
    public void SetSprite(Sprite sprite)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = sprite;
        }
    }

    // Method to rotate the sprite 60 degrees to the left
    public void RotateLeft()
    {
        transform.Rotate(0, 0, 60); // Rotate 60 degrees around the z-axis
    }

    // Method to rotate the sprite 60 degrees to the right
    public void RotateRight()
    {
        transform.Rotate(0, 0, -60); // Rotate -60 degrees around the z-axis
    }

    // Method to place the GamePiece on the grid
    public void PlaceOnGrid(Vector3Int newGridPosition, Grid grid)
    {
        this.grid = grid;
        this.gridPosition = newGridPosition;
        transform.position = grid.CellToWorld(gridPosition);
        transform.Rotate(0, 0, 30);
    }

    public Vector3Int GetGridPosition()
    {
        return gridPosition;
    }

    private void OnMouseDown()
    {
        if(isSelected)
        {

            isSelected = false;
        }
        else
        {
            RotateRight();
            isSelected = true;
        }
        Debug.Log("GamePiece clicked!");
        HexGrid hexGrid = FindObjectOfType<HexGrid>(); // Find the HexGrid in the scene
        //hexGrid.HighlightAdjacentHexes(hexCoordinates, true);
        List<Vector3Int> positionsToHighlight = GetPositionsWithinRange(new Vector3Int(hexCoordinates.x, hexCoordinates.y), 3);
        hexGrid.HighlightHexes(positionsToHighlight, isSelected);

    }

    

    // Method to get positions within a certain rangeusing System.Collections.Generic;

    List<Vector3Int> GetPositionsWithinRange(Vector3Int center, int range)
    {
        HashSet<Vector3Int> positions = new HashSet<Vector3Int>();

        int width = range * 2;

        for (int yOffset = -range; yOffset <= range; yOffset++)
        {
            int currentY = center.y + yOffset;
            int currentWidth = width - Mathf.Abs(yOffset);

            for (int x = 0; x <= currentWidth; x++)
            {
                Vector3Int position = new Vector3Int(center.x - (currentWidth / 2) + x, currentY, center.z);
                positions.Add(position);
            }
        }

        return new List<Vector3Int>(positions);
    }


}

