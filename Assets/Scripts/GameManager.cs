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
        int x = 1;
        int y = 3;

        GameObject gamePiece = Instantiate(gamePiecePrefab);
        gamePiece.GetComponent<GamePiece>().Initialize(new Vector3Int(x, y, 1), hexGrid.GetHexAt(new Vector3Int(x, y)));
        //gamePiece.GetComponent<GamePiece>().PlaceOnGrid(new Vector3Int(x, y, 1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
