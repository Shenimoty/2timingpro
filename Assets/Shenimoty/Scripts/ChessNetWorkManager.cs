using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ChessNetWorkManager : MonoBehaviourPunCallbacks
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        print("OnConnectedToServer");

        RoomOptions roomOptions=new RoomOptions();
        roomOptions.MaxPlayers=2;
        PhotonNetwork.JoinOrCreateRoom("ZXM'S CHESSROOM",roomOptions,TypedLobby.Default);

    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("OnJoinedRoom");
        if(player==null) return;
        GameObject newPlayer=PhotonNetwork.Instantiate(player.name,Vector3.zero,player.transform.rotation);
        if(PhotonNetwork.IsMasterClient)
        {
            newPlayer.GetComponent<ChessPlayer>().pieceColor=PieceColor.Black;
        }
        else
        {
            newPlayer.GetComponent<ChessPlayer>().pieceColor=PieceColor.White;
        }
    }

}
