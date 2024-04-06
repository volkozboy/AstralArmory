using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Guns;
public class TankAmmoManager : MonoBehaviour
{
    void OnTriggerEnter(Collider colider){
        if(colider.CompareTag("Ammunition")){
            FindObjectOfType<Rocket>().MaxAmmoNumber += 1;
            FindObjectOfType<SMG>().MaxAmmoNumber += 1;
        }
    }
}

