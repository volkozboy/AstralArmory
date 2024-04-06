using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    
    public bool gunEquipped;
    public int pickupDis;
    public Transform target, gunContainer;

    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        gunContainer = GameObject.FindGameObjectWithTag("GunContainer").transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(target.position, transform.position) < pickupDis && Input.GetKeyDown(KeyCode.E)){
            Pickup();
        }
        if(gunEquipped && Input.GetKeyDown(KeyCode.Backspace)){
            Drop();
        }
    }

    void Pickup(){
        gunEquipped = true;
        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        rb.isKinematic = true;
    }

    void Drop(){
        gunEquipped = false;
        transform.SetParent(null);
        rb.isKinematic = false;
    }
}
