using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hex : MonoBehaviour
{
    private bool isSelected = false;

    private Vector2Int hexCoordinates;

    public void SetCoordinates(Vector2Int coordinates)
    {
        hexCoordinates = coordinates;
    }

    private void OnMouseDown()
    {
        if (isSelected)
        {
            isSelected = false;
        }
        else
        {
            isSelected = true;
        }
        Debug.Log("Open Tile clicked!");


    }
}
