using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class MyUsername : MonoBehaviourPunCallbacks, IPunObservable
{
    public TextMeshProUGUI username;
    private string savedUsername = "DefaultUser";

    new PhotonView photonView;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (photonView.IsMine) // Check if the PhotonView belongs to the local player
        {
            savedUsername = PlayerPrefs.GetString("PlayerUsername", "DefaultUser"); // Retrieve the saved username
            photonView.RPC("UpdateUsername", RpcTarget.AllBuffered, savedUsername); // Update the username across the network
        }
    }

    [PunRPC]
    void UpdateUsername(string username)
    {
        this.username.text = "" + username; // Display the retrieved username
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Send the username data
            stream.SendNext(savedUsername);
        }
        else
        {
            // Receive the username data
            savedUsername = (string)stream.ReceiveNext();
            UpdateUsername(savedUsername);
        }
    }
}