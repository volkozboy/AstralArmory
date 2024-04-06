using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PistolEquip : MonoBehaviour
{
    
    public Transform target, gunContainer, pistol;
    
    
    void Start()
    {
        gunContainer = GameObject.FindGameObjectWithTag("GunContainer").transform;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
