using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Play;
using TMPro;
using UnityEngine.UI;

public class Shotgun : MonoBehaviour
{

    public Transform gunPoint1;
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

        if(Input.GetButtonDown("Fire1") && ammo > 0 && nextFire <= 0){
            if(MaxAmmo){
                nextFire = 1 / fireRate;
                view.RPC("ShootingAnim", RpcTarget.All);
            }
            
        }
        if(Input.GetKeyDown(KeyCode.R) && MaxAmmoNumber > 0 && ammo < 6){
            view.RPC("ReloadingAnim", RpcTarget.All);
        }
        if(ammo < 0){
            ammo = 0;
        }
        if(MaxAmmoNumber > 3){
            MaxAmmoNumber = 3;
        }
        CurrentAmmo.value = ammo;
        CurrentAmmo.maxValue = 6;
        MaxAmmo.text = "" + MaxAmmoNumber;
        }
        
    }

    [PunRPC]
    void ShootingAnim(){
        anim.Play("ShotgunShooting");
    }
    [PunRPC]
    void ReloadingAnim(){
        anim.Play("ShotgunReloading");
    }

   void Shoot()
{
    if (!view.IsMine)
    {
        return;
    }

    if (view.IsMine)
    {
        view.RPC("PlayAudioRPC", RpcTarget.All);
        int pellets = 8; // Number of pellets in the shotgun blast
        float spreadAngle = 10f; // The angle of the shotgun spread

        ammo--;

        for (int i = 0; i < pellets; i++)
        {
            // Calculate a random direction within the spread angle
            Vector3 randomDirection = Quaternion.Euler(
                Random.Range(-spreadAngle, spreadAngle),
                Random.Range(-spreadAngle, spreadAngle),
                0
            ) * mainCam.transform.forward;

            RaycastHit hit;

            if (Physics.Raycast(mainCam.transform.position, randomDirection, out hit, 100f))
            {
                Debug.DrawRay(mainCam.transform.position, randomDirection * hit.distance, Color.red, 100f);
                Instantiate(Sparks, hit.point, Quaternion.LookRotation(hit.normal));
                if (hit.transform.gameObject.GetComponent<Health>())
                {
                    hit.transform.gameObject.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.All, damage);
                    FindObjectOfType<AudioManager>().Play("Hit"); // Play shotgun firing sound
                    StartCoroutine(hitIndiccation());
                }
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
        GameObject LaserBP1 = Instantiate(LaserPrefab, gunPoint1.position, transform.rotation * Quaternion.Euler(10, 10, 85));
        GameObject LaserBP2 = Instantiate(LaserPrefab, gunPoint1.position, transform.rotation * Quaternion.Euler(10, 30, 90));
        GameObject LaserBP3 = Instantiate(LaserPrefab, gunPoint1.position, transform.rotation * Quaternion.Euler(15, 25, 80));
        GameObject LaserBP4 = Instantiate(LaserPrefab, gunPoint1.position, transform.rotation * Quaternion.Euler(20, 15, 70));
        GameObject LaserBP5 = Instantiate(LaserPrefab, gunPoint1.position, transform.rotation * Quaternion.Euler(10, 20, 95));
        GameObject LaserBP6 = Instantiate(LaserPrefab, gunPoint1.position, transform.rotation * Quaternion.Euler(20, 10, 75));
    }


    void Reloading(){
        ammo = 6;
        MaxAmmoNumber -= 1;

        if(MaxAmmoNumber < 0){
            MaxAmmoNumber = 0;
        }
    }

}
