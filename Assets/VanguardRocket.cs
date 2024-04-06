using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Play;
using TMPro;
using UnityEngine.UI;

public class VanguardRocket : MonoBehaviour
{

    public Transform gunPoint;
    public Camera playerCam;
    public int MaxAmmoNumber = 10;
    public int ammo;
    public int bulletsShot;
    PhotonView view;
    public int damage;
    public float fireRate;
    public float nextFire;
    public Animator anim;
    public GameObject RocketPrefab;
    public AudioSource audioSource;

    public Slider CurrentAmmo;
    public TextMeshProUGUI MaxAmmo;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();

        playerCam = Camera.main;
        
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!view.IsMine){
            return;
        }
        if(view.IsMine){
            if(nextFire > 0){
            nextFire -= Time.deltaTime;
        }

        if(Input.GetButtonDown("Fire1") && ammo > 0 && nextFire <= 0){
            if(MaxAmmo){
                nextFire = 1 / fireRate;
                view.RPC("ShootingAnim", RpcTarget.All);
            }
            
        }
        if(Input.GetKeyDown(KeyCode.R) && MaxAmmoNumber > 0 && ammo < 5){
            view.RPC("ReloadingAnim", RpcTarget.All);
        }
        if(ammo < 0){
            ammo = 0;
        }
        if(MaxAmmoNumber > 10){
            MaxAmmoNumber = 10;
        }
        CurrentAmmo.value = ammo;
        CurrentAmmo.maxValue = 5;
        MaxAmmo.text = "" + MaxAmmoNumber;
        }
        
    }

    [PunRPC]
    void ShootingAnim(){
        anim.Play("VanguardRocketShooting");
    }
    [PunRPC]
    void ReloadingAnim(){
        anim.Play("VanguardRocketReloading");
    }
     [PunRPC]
    void SoundAnim(){
        
        view.RPC("PlayAudioRPC", RpcTarget.All);
    }
    [PunRPC]
    void PlayAudioRPC()
    {
        audioSource.Play(); // Play the audio for all clients
    }

    void Shoot(){
        if(!view.IsMine){
            return;
        }
        if(view.IsMine){
            ammo --;
        }
        }
        
        void RocketBall(){
            GameObject LaserBP = Instantiate(RocketPrefab, gunPoint.position, transform.rotation * Quaternion.Euler(0, 0, 90));
        } 
    


    void Reloading(){
        ammo = ammo + 1;
        MaxAmmoNumber -= 1;
        if(ammo > 5){
            ammo = 5;
        }
        if(MaxAmmoNumber < 0){
            MaxAmmoNumber = 0;
        }
    }
}