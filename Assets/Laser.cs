using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Laser : MonoBehaviour
{
    public int speed;
    Transform player;
    Vector2 target;

    Rigidbody rb;
    void Start(){
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Bullet(gameObject));
    }

    void Update(){
        rb.AddForce(transform.up * speed * Time.deltaTime, ForceMode.Impulse);
    }

    IEnumerator Bullet(GameObject laser){
        yield return new WaitForSeconds(3);
        Destroy(laser);
    }
}