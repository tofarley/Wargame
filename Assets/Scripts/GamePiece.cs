using UnityEngine;

public class GamePiece : MonoBehaviour
{
    public Vector2Int hexCoordinates;
    public GameObject currentHexTile;

    public int moveDistance;
    
    // Initialize the GamePiece on a specific hex tile
    public void Initialize(Vector2Int coordinates, GameObject hexTile)
    {
        hexCoordinates = coordinates;
        currentHexTile = hexTile;
        this.transform.position = hexTile.transform.position; // Align the game piece with the hex tile
    }

    void OnMouseDown()
    {
        // This code will be executed when the player clicks on the GameObject this script is attached to
        Debug.Log("GamePiece clicked at X=" + hexCoordinates.x + " and Y=" + hexCoordinates.y);
        // Do this as a unity setting
        HexGrid hexGrid = FindObjectOfType<HexGrid>(); // Find the HexGrid in the scene
        hexGrid.HighlightAdjacentHexes(hexCoordinates, true);
    }
}