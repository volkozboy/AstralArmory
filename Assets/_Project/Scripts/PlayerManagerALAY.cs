using UnityEngine;
using Photon.Pun;

public class PlayerManagerALAY : MonoBehaviourPunCallbacks, IPunObservable
{
    public GameObject[] playerModelPrefabs; // Array of player model prefabs
    private GameObject currentPlayerModel;

    private int currentModelIndex = 0; // Index of the current player model

    private void Start()
    {
        if (photonView.IsMine)
        {
            // Instantiate the initial player model for the local player
            currentPlayerModel = PhotonNetwork.Instantiate(playerModelPrefabs[currentModelIndex].name, transform.position, transform.rotation);
        }
    }

    private void Update()
    {
        if (!photonView.IsMine)
            return;

        // Player input and logic for the local player

        // Example: Switching player models with number keys 1, 2, 3...
        for (int i = 0; i < playerModelPrefabs.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                currentModelIndex = i;
                photonView.RPC("SwitchPlayerModelRPC", RpcTarget.All, currentModelIndex);
                break;
            }
        }
    }

    [PunRPC]
    private void SwitchPlayerModelRPC(int modelIndex)
    {
        // Destroy the current player model for all clients
        if (currentPlayerModel != null)
        {
            PhotonNetwork.Destroy(currentPlayerModel);
        }

        // Instantiate the new player model for all clients
        currentPlayerModel = PhotonNetwork.Instantiate(playerModelPrefabs[modelIndex].name, transform.position, transform.rotation);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Send the currentModelIndex value to other clients
            stream.SendNext(currentModelIndex);
        }
        else
        {
            // Receive the currentModelIndex value from the network
            currentModelIndex = (int)stream.ReceiveNext();
        }
    }
}