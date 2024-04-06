using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class VanAssaultSwitcher : MonoBehaviourPun
{
    public GameObject AssaultRifle;
    public GameObject AssaultRifleRender;
    public GameObject Shotgun;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        // Only process input if the local player controls this GameObject
        if (photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                // Call the RPC to switch to Weapon1
                photonView.RPC("SwitchToWeapon1", RpcTarget.All);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                // Call the RPC to switch to Weapon2
                photonView.RPC("SwitchToWeapon2", RpcTarget.All);
            }
        }
    }

    [PunRPC]
    private void SwitchToWeapon1()
    {
        // Switch to Weapon1 on all clients
        Shotgun.GetComponent<MeshRenderer>().enabled = false;
        Shotgun.GetComponent<VanguardShotgun>().enabled = false;
        AssaultRifleRender.GetComponent<MeshRenderer>().enabled = true;
        AssaultRifle.GetComponent<VanguardAssaultRifle>().enabled = true;
    }

    [PunRPC]
    private void SwitchToWeapon2()
    {
        // Switch to Weapon2 on all clients
        AssaultRifleRender.GetComponent<MeshRenderer>().enabled = false;
        AssaultRifle.GetComponent<VanguardAssaultRifle>().enabled = false;
        Shotgun.GetComponent<MeshRenderer>().enabled = true;
        Shotgun.GetComponent<VanguardShotgun>().enabled = true;
    }
}
