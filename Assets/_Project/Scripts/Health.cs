using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Play;
using UnityEngine.UI;

public class Health : MonoBehaviourPunCallbacks
{
    public int health;
    public int maxHealth;
    public float shield;
    public TextMeshProUGUI healthText;
    public Slider ShieldText;
    public GameObject Shieldd;

    public bool Support;
    public bool Assault;
    public bool Tank;

    PhotonView view;
    public Camera cameraa;
    public LayerMask TemaVieww;

    public GameObject Team;
    public GameObject playerCanvas;

    [Header("RagdollModels")]
    public GameObject SupportRagdoll;
    public GameObject AssaultRagdoll;
    public GameObject TankRagdoll;

    void Start()
    {
        view = GetComponent<PhotonView>();

        if (view.IsMine)
        {
            playerCanvas = GameObject.FindWithTag("Canvas");
            // Initialize health and shield for the local player based on class
            if (Support)
            {
                health = 100;
                maxHealth = 100;
                shield = 100;
            }
            else if (Assault)
            {
                health = 100;
                maxHealth = 100;
                shield = 150;
            }
            else if (Tank)
            {
                health = 200;
                maxHealth = 200;
                shield = 150;
            }
            

            // Update the network with the initial health and shield values
            view.RPC("SyncHealthAndShield", RpcTarget.AllBuffered, health, shield);
        }
    }

    void Update()
    {
        if (view.IsMine)
        {
            healthText.text = "+" + health;
            ShieldText.value = shield;

            Shieldd.SetActive(true);
            
            if(Support && shield > 100){
                shield = 100;
            }
            if(Support && health > 100){
                health = 100;
            }
            
            if(Assault && shield > 150){
                shield = 150;
            }
            if(Assault && health > 100){
                health = 100;
            }

            if(Tank && shield > 150){
                shield = 150;
            }
            if(Tank && health > 200){
                health = 200;
            }
            
            if(shield < 150){
                shield += Time.deltaTime * 5f;
            }
        }
    }

    [PunRPC]
    public void SyncHealthAndShield(int _health, float _shield)
    {
        health = _health;
        shield = _shield;
    }

    [PunRPC]
    public void TakeDamage(int _damage)
    {
        if (view.IsMine)
        {
            shield -= _damage;

            if (shield <= 0)
            {
                health -= _damage;
            }

            if (health <= 0)
            {
                photonView.RPC("Die", RpcTarget.All); // Synchronize player death
            }
        }
    }

    [PunRPC]
    public void Die()
    {
        if(Assault){
            PhotonNetwork.Instantiate(AssaultRagdoll.name, gameObject.transform.position, Quaternion.identity);
        }
        if(Tank){
            PhotonNetwork.Instantiate(TankRagdoll.name, gameObject.transform.position, Quaternion.identity);
        }
        if(Support){
            PhotonNetwork.Instantiate(SupportRagdoll.name, gameObject.transform.position, Quaternion.identity);
        }
        if(view.IsMine){
            playerCanvas.SetActive(true);
        }
        Destroy(gameObject); // Example: Destroy the player GameObject
    }

}