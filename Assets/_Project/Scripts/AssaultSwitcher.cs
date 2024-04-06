using UnityEngine;
using Photon.Pun;

public class AssaultSwitcher : MonoBehaviourPun, IPunObservable
{
    public bool Rifle;
    public bool Shotgun;
    public GameObject ShotgunOb;
    public GameObject RifleOb;

    private void Start()
    {
        if (!photonView.IsMine)
        {
            // Disable player models for other players
            SetPlayerModelActive(false);
        }
    }

    private void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Rifle = true;
            Shotgun = false;
            photonView.RPC("SwitchPlayerModelRPC", RpcTarget.AllBuffered, Rifle, Shotgun);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Shotgun = true;
            Rifle = false;
            photonView.RPC("SwitchPlayerModelRPC", RpcTarget.AllBuffered, Rifle, Shotgun);
        }
    }

    [PunRPC]
    private void SwitchPlayerModelRPC(bool rifleActive, bool shotgunActive)
    {
        Rifle = rifleActive;
        Shotgun = shotgunActive;

        // Set the active state of player models based on the flags
        SetPlayerModelActive(Rifle, Shotgun);
    }

    private void SetPlayerModelActive(bool rifleActive, bool shotgunActive)
    {
        RifleOb.SetActive(rifleActive);
        ShotgunOb.SetActive(shotgunActive);
    }

    private void SetPlayerModelActive(bool active)
    {
        RifleOb.SetActive(active);
        ShotgunOb.SetActive(active);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Send the active states to other clients
            stream.SendNext(Rifle);
            stream.SendNext(Shotgun);
        }
        else
        {
            // Receive the active states from the network
            Rifle = (bool)stream.ReceiveNext();
            Shotgun = (bool)stream.ReceiveNext();

            // Set the active state of player models based on the received states
            SetPlayerModelActive(Rifle, Shotgun);
        }
    }
}