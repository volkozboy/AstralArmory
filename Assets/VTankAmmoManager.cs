using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Guns;
public class VTankAmmoManager : MonoBehaviour
{
void OnTriggerEnter(Collider colider){
        if(colider.CompareTag("Ammunition")){
            FindObjectOfType<VanguardRocket>().MaxAmmoNumber += 1;
            FindObjectOfType<VanguardSMG>().MaxAmmoNumber += 1;
        }
    }
}
