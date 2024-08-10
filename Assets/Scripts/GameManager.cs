using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Reference to the GamePiece prefab
    public GameObject gamePiecePrefab;

    [SerializeField] private HexGrid hexGrid;

    // Start is called before the first frame update
    void Start()
    {
        int x = 3;
        int y = 3;
        Vector3Int startPosition = new Vector3Int(x, y);
        GameObject gamePiece = Instantiate(gamePiecePrefab);
        gamePiece.GetComponent<GamePiece>().Initialize(startPosition, hexGrid.GetHexAt(startPosition));
    }


}
