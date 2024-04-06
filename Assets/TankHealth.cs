using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Play;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public int health;
    public int shield;
    public Text healthText;

    PhotonView view;

    void Start(){
        view = GetComponent<PhotonView>();
    }
    void Update(){
        if(view.IsMine){
            healthText.text = "Health: " + health;
        }
    }
   [PunRPC]
   public void TakeDamage(int _damage){
    
    shield -= _damage;

    if(shield <= 0){
        health -= _damage;
    }
    
    if(health <= 0){
        Destroy(gameObject);
    }
   }
}
