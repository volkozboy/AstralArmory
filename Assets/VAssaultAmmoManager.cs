using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Guns;
public class VAssaultAmmoManager : MonoBehaviour
{
    void OnTriggerEnter(Collider colider){
        if(colider.CompareTag("Ammunition")){
            FindObjectOfType<VanguardAssaultRifle>().MaxAmmoNumber += 1;
            FindObjectOfType<VanguardShotgun>().MaxAmmoNumber += 1;
        }
    }
}

