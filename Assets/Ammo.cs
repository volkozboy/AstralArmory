// Ammo.cs
using UnityEngine;

public class Ammo : MonoBehaviour
{

    void OnTriggerEnter(Collider collider)
    {
        Destroy(gameObject);
    }
}