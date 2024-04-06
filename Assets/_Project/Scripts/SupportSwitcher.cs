using UnityEngine;
using Photon.Pun;

public class SupportSwitcher : MonoBehaviourPun, IPunObservable
{
    public bool Pistol;
    public bool Sniper;
    public GameObject SniperOb;
    public GameObject PistolOb;

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
            Pistol = true;
            Sniper = false;
            photonView.RPC("SwitchPlayerModelRPC", RpcTarget.AllBuffered, Pistol, Sniper);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Sniper = true;
            Pistol = false;
            photonView.RPC("SwitchPlayerModelRPC", RpcTarget.AllBuffered, Pistol, Sniper);
        }
    }

    [PunRPC]
    private void SwitchPlayerModelRPC(bool pistolActive, bool sniperActive)
    {
        Pistol = pistolActive;
        Sniper = sniperActive;

        // Set the active state of player models based on the flags
        SetPlayerModelActive(Pistol, Sniper);
    }

    private void SetPlayerModelActive(bool pistolActive, bool sniperActive)
    {
        PistolOb.SetActive(pistolActive);
        SniperOb.SetActive(sniperActive);
    }

    private void SetPlayerModelActive(bool active)
    {
        PistolOb.SetActive(active);
        SniperOb.SetActive(active);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Send the active states to other clients
            stream.SendNext(Pistol);
            stream.SendNext(Sniper);
        }
        else
        {
            // Receive the active states from the network
            Pistol = (bool)stream.ReceiveNext();
            Sniper = (bool)stream.ReceiveNext();

            // Set the active state of player models based on the received states
            SetPlayerModelActive(Pistol, Sniper);
        }
    }
}