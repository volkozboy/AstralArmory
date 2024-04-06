using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Guns;
public class VSupportAmmoManager : MonoBehaviour
{
void OnTriggerEnter(Collider colider){
        if(colider.CompareTag("Ammunition")){
            FindObjectOfType<VanguardSniper>().MaxAmmoNumber += 1;
            FindObjectOfType<VanguardPistol>().MaxAmmoNumber += 1;
        }
    }
}
