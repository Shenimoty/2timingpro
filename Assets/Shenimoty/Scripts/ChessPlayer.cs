using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ChessPlayer : MonoBehaviour
{
    public Vector3 zeroPointPosition;
    public float cellWidth;
    public PieceColor pieceColor =PieceColor.Black;
    private PhotonView pv;
    private int row;
    private int column;
    public GameObject black_Piece;
    public GameObject white_Piece;
    // Start is called before the first frame update
    void Start()
    {
        pv=this.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!pv.IsMine) return;
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 offsetPos=mousePos-zeroPointPosition;
            row=(int)Mathf.Round(offsetPos.y/cellWidth);
            column=(int)Mathf.Round(offsetPos.x/cellWidth);
            if(row<0||row>14||column<0||column>14) return;
            
            Vector3 piecePos=new Vector3(column*cellWidth,row*cellWidth,zeroPointPosition.z)+zeroPointPosition;

            GameObject newPiece;
            if(pieceColor==PieceColor.Black)
            {
                if(black_Piece!=null)
                {
                newPiece=PhotonNetwork.Instantiate(black_Piece.name,piecePos,black_Piece.transform.rotation);
                newPiece.GetComponent<ChessPiece>().row=row;
                newPiece.GetComponent<ChessPiece>().column=column;
                }
            }
            else
            {
                if(white_Piece!=null)
                {
                newPiece=PhotonNetwork.Instantiate(white_Piece.name,piecePos,black_Piece.transform.rotation);
                newPiece.GetComponent<ChessPiece>().row=row;
                newPiece.GetComponent<ChessPiece>().column=column;
                }
            }
        }
    }
}
