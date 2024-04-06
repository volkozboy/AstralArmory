using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Play;
using TMPro;
using UnityEngine.UI;
namespace Guns
{
public class VanguardPistol : MonoBehaviour
{

    public Transform gunPoint;
    public Camera mainCam;
    public int MaxAmmoNumber = 15;
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
        if(Input.GetKeyDown(KeyCode.R) && MaxAmmoNumber > 0 && ammo < 15){
            view.RPC("ReloadingAnim", RpcTarget.All);
        }
        if(ammo < 0){
            ammo = 0;
        }
        if(MaxAmmoNumber > 8){
            MaxAmmoNumber = 8;
        }

        CurrentAmmo.value = ammo;
        CurrentAmmo.maxValue = 15;
        MaxAmmo.text = "" + MaxAmmoNumber;
                
        }  
    }

    [PunRPC]
    void ShootingAnim(){
        anim.Play("VanguardPistolShooting");
    }
    [PunRPC]
    void ReloadingAnim(){
        anim.Play("VanguardPistolReloading");
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
            Debug.Log(hit.transform.name);
            Debug.DrawRay(mainCam.transform.position, gunPoint.forward, Color.red, 100f);
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

    void Laser(){
        GameObject LaserBP = Instantiate(LaserPrefab, gunPoint.position, transform.rotation * Quaternion.Euler(0, 0, 90));
    }

    void Reloading(){
        ammo = 15;
        MaxAmmoNumber -= 1;

        if(MaxAmmoNumber < 0){
            MaxAmmoNumber = 0;
        }
    }

}
}