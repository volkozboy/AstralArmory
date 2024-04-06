using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyBullet : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject LobGunPOint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BulletLobby(){
        GameObject LaserLob = Instantiate(Bullet, LobGunPOint.transform.forward, transform.rotation * Quaternion.Euler(0, 0, 90));
    }
}
