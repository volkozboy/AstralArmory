using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Play;
using Guns;
using TMPro;
using UnityEngine.UI;
public class VanguardAssaultRifle : MonoBehaviour
{

    public Transform gunPoint;
    public Camera mainCam;
    public int MaxAmmoNumber = 10;
    public int ammo;
    public int bulletsShot;
    PhotonView view;
    public int damage;
    public float fireRate;
    public float nextFire;
    public Animator anim;
    public GameObject LaserPrefab;

    public Slider CurrentAmmo;
    public TextMeshProUGUI MaxAmmo;
    public GameObject hitIndicator;
    public AudioSource audioSource;

    public ParticleSystem Sparks;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        
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

        if(Input.GetButton("Fire1") && ammo > 0 && nextFire <= 0){
            if(MaxAmmo){
                nextFire = 1 / fireRate;
                view.RPC("ShootingAnim", RpcTarget.All);
            }
            
        }
        if(Input.GetKeyDown(KeyCode.R) && MaxAmmoNumber > 0 && ammo < 30){
            view.RPC("ReloadingAnim", RpcTarget.All);
        }
        if(ammo < 0){
            ammo = 0;
        }
        if(MaxAmmoNumber > 5){
            MaxAmmoNumber = 5;
        }
        CurrentAmmo.value = ammo;
        CurrentAmmo.maxValue = 30;
        MaxAmmo.text = "" + MaxAmmoNumber;
        }

       
    }

    IEnumerator Shoot(){
        if(!view.IsMine){

        }
        if(view.IsMine){
            RaycastHit hit;
            ammo --;
            view.RPC("PlayAudioRPC", RpcTarget.All);
            yield return new WaitForSeconds(0.1f);
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, 1000f)){
            Debug.DrawRay(mainCam.transform.position, gunPoint.forward, Color.red, 1000f);
            Instantiate(Sparks, hit.point, Quaternion.LookRotation(hit.normal));
            if(hit.transform.gameObject.GetComponent<Health>()){
                hit.transform.gameObject.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.All, damage);
                FindObjectOfType<AudioManager>().Play("Hit");
                StartCoroutine(hitIndiccation());
            }
        }
        
        }
        
            
    }
    [PunRPC]
    void PlayAudioRPC()
    {
        audioSource.Play(); // Play the audio for all clients
    }

    IEnumerator hitIndiccation(){
        hitIndicator.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        hitIndicator.SetActive(false);
    }

    [PunRPC]
    void ShootingAnim(){
        anim.Play("VanguardARShooting");
    }
    [PunRPC]
    void ReloadingAnim(){
        anim.Play("VanguardARReloading");
    }

    void Laser(){
        GameObject LaserBP = Instantiate(LaserPrefab, gunPoint.position, transform.rotation * Quaternion.Euler(0, 90, 90));
    }

    
    void Reloading(){
        ammo = 30;
        MaxAmmoNumber -= 1;

        if(MaxAmmoNumber < 0){
            MaxAmmoNumber = 0;
        }
    }

}
