using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RIfleEquip : MonoBehaviour
{
    public Transform target, gunContainer, rifle;
    
    
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
