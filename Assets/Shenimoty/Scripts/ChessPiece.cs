using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public enum PieceColor
{
    Black=0,
    White=1,
}
public class ChessPiece : MonoBehaviour
{
    public int row;
    public int column;
    public PieceColor pieceColor =PieceColor.Black;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
