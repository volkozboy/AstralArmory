using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AssaultGunSwitching : MonoBehaviourPun
{
    public GameObject AssaultRifle;
    public GameObject AssaultRifleRenderer;
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
        Shotgun.GetComponent<Shotgun>().enabled = false;
        AssaultRifleRenderer.GetComponent<MeshRenderer>().enabled = true;
        AssaultRifle.GetComponent<AssaultRifle>().enabled = true;
    }

    [PunRPC]
    private void SwitchToWeapon2()
    {
        // Switch to Weapon2 on all clients
        AssaultRifleRenderer.GetComponent<MeshRenderer>().enabled = false;
        AssaultRifle.GetComponent<AssaultRifle>().enabled = false;
        Shotgun.GetComponent<MeshRenderer>().enabled = true;
        Shotgun.GetComponent<Shotgun>().enabled = true;
    }
}
