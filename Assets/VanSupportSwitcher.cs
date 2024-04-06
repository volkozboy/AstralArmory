using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Guns;
public class VanSupportSwitcher : MonoBehaviourPun
{
    public GameObject Sniper;
    public GameObject Pistol;
    public GameObject PistolPart;

    public GameObject AstralFalcon;
        public GameObject AstralFalconPart1;
        public GameObject AstralFalconPart2;
        public GameObject AstralFalconCylinder1;
        public GameObject AstralFalconCylinder2;
    public bool FalconTime;

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
            if(Input.GetKeyDown(KeyCode.Alpha5)){
                FalconTime = true;
            }
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
             if(Input.GetKeyDown(KeyCode.Alpha9) && FalconTime){
                photonView.RPC("SwitchToWeapon3", RpcTarget.All);
            }
        }
    }

     [PunRPC]
    private void SwitchToWeapon1()
    {
        // Switch to Weapon1 on all clients
        Pistol.GetComponent<MeshRenderer>().enabled = false;
        PistolPart.GetComponent<MeshRenderer>().enabled = false;
        Pistol.GetComponent<VanguardPistol>().enabled = false;
        Sniper.GetComponent<MeshRenderer>().enabled = true;
        Sniper.GetComponent<VanguardSniper>().enabled = true;

        AstralFalconPart1.GetComponent<MeshRenderer>().enabled = false;
        AstralFalconPart2.GetComponent<MeshRenderer>().enabled = false;
        AstralFalconCylinder1.GetComponent<MeshRenderer>().enabled = false;
        AstralFalconCylinder2.GetComponent<MeshRenderer>().enabled = false;
        AstralFalcon.GetComponent<AstralFalcon>().enabled = false;
    }

    [PunRPC]
    private void SwitchToWeapon2()
    {
        // Switch to Weapon2 on all clients
        Sniper.GetComponent<MeshRenderer>().enabled = false;
        Sniper.GetComponent<VanguardSniper>().enabled = false;
        Pistol.GetComponent<MeshRenderer>().enabled = true;
        PistolPart.GetComponent<MeshRenderer>().enabled = true;
        Pistol.GetComponent<VanguardPistol>().enabled = true;

        AstralFalconPart1.GetComponent<MeshRenderer>().enabled = false;
        AstralFalconPart2.GetComponent<MeshRenderer>().enabled = false;
        AstralFalconCylinder1.GetComponent<MeshRenderer>().enabled = false;
        AstralFalconCylinder2.GetComponent<MeshRenderer>().enabled = false;
        AstralFalcon.GetComponent<AstralFalcon>().enabled = false;
    }
    [PunRPC]
    private void SwitchToWeapon3()
    {
        // Switch to Weapon2 on all clients
        Sniper.GetComponent<MeshRenderer>().enabled = false;
        Sniper.GetComponent<VanguardSniper>().enabled = false;
        Pistol.GetComponent<MeshRenderer>().enabled = false;
        PistolPart.GetComponent<MeshRenderer>().enabled = false;
        Pistol.GetComponent<VanguardPistol>().enabled = false;

        AstralFalconPart1.GetComponent<MeshRenderer>().enabled = true;
        AstralFalconPart2.GetComponent<MeshRenderer>().enabled = true;
        AstralFalconCylinder1.GetComponent<MeshRenderer>().enabled = true;
        AstralFalconCylinder2.GetComponent<MeshRenderer>().enabled = true;
        AstralFalcon.GetComponent<AstralFalcon>().enabled = true;
    }
}

