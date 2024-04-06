using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    
    public InputField createInput;
    public InputField joinInput;

    public RoomItem roomitemPrefab;
    List<RoomItem> roomItemsList = new List<RoomItem>();
    public Transform contentObject;

    public Toggle FFA;
        public Toggle SammyStation;

    public Toggle TDM;

    public Toggle CS;

    
    
   public void CreateRoom()
{
    string selectedMode = "FFA";
    if (TDM.isOn)
    {
        selectedMode = "TDM";
    }
    if(CS.isOn){
        selectedMode = "CS";
    }
    ExitGames.Client.Photon.Hashtable customRoomProperties = new ExitGames.Client.Photon.Hashtable() { { "GameMode", selectedMode } };
    PhotonNetwork.CreateRoom(createInput.text, new Photon.Realtime.RoomOptions { CustomRoomProperties = customRoomProperties, CustomRoomPropertiesForLobby = new string[] { "GameMode" } });
}

public void JoinRoom()
{
    PhotonNetwork.JoinRoom(joinInput.text);
}

public override void OnJoinedRoom()
{
    if (PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue("GameMode", out var gameMode))
    {
        if (gameMode.ToString() == "FFA")
        {
            PhotonNetwork.LoadLevel("FFA (Sammy Station)");
        }
        else if (gameMode.ToString() == "TDM")
        {
            PhotonNetwork.LoadLevel("TDM (Unknown)");
        }
         else if (gameMode.ToString() == "CS")
        {
            PhotonNetwork.LoadLevel("CS (Unknown)");
        }
    }
}

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateRoomList(roomList);

    }

    void UpdateRoomList(List<RoomInfo> list){
        foreach (RoomItem item in roomItemsList){
            Destroy(item.gameObject);
        }
        roomItemsList.Clear();

        foreach(RoomInfo room in list){
            RoomItem newRoom = Instantiate(roomitemPrefab, contentObject);
            newRoom.SetRoomName(room.Name);
            roomItemsList.Add(newRoom);
        }
    }

    public void JoinRoom(string roomName){
        PhotonNetwork.JoinRoom(roomName);
    }
    

}