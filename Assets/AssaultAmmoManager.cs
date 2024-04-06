using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Guns;
public class AssaultAmmoManager : MonoBehaviour
{
    void OnTriggerEnter(Collider colider){
        if(colider.CompareTag("Ammunition")){
            FindObjectOfType<AssaultRifle>().MaxAmmoNumber += 1;
            FindObjectOfType<Shotgun>().MaxAmmoNumber += 1;
        }
    }
}
