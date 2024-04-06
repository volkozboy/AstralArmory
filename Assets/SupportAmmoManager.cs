using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Guns;
public class SupportAmmoManager : MonoBehaviour
{
void OnTriggerEnter(Collider colider){
        if(colider.CompareTag("Ammunition")){
            FindObjectOfType<Sniper>().MaxAmmoNumber += 1;
            FindObjectOfType<Pistol>().MaxAmmoNumber += 1;
        }
    }
}
