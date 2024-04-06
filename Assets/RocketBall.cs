using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RocketBall : MonoBehaviour
{
    public float speed;
    public ParticleSystem particle;
    public Transform explosionCheck;
    public float explosionDistance = 1;
    public LayerMask explosionMask;
    public int launchForce = 10;
    public int damage = 80;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Move the RocketBall forward based on speed
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collider)
    {
        particle.Play();
        StartCoroutine(Delay());
        speed = 0;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        Explode();
        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] hitColliders = Physics.OverlapSphere(explosionCheck.position, explosionDistance, explosionMask);
        
        foreach (Collider hitCollider in hitColliders)
        {
            // Check if the hitCollider's GameObject has a Health component
            Health healthComponent = hitCollider.GetComponent<Health>();

            if (healthComponent != null)
            {
                // Apply damage through an RPC call to the player's PhotonView
                healthComponent.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.All, damage);
                FindObjectOfType<AudioManager>().Play("Hit"); // Play audio for hit
            }

            // Apply force to character controller
            CharacterController characterController = hitCollider.GetComponent<CharacterController>();
            if (characterController != null)
            {
                Vector3 direction = (characterController.transform.position - explosionCheck.position).normalized;
                characterController.Move(direction * launchForce * Time.deltaTime);
            }
        }
    }
}




