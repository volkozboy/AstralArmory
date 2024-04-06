using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmokitSpawn : MonoBehaviour
{
    public GameObject AmmoPrefab;
    public GameObject AmmoSpawn;

    private GameObject currentAmmo;

    void Start()
    {
        StartCoroutine(AmmoCoolDown());
    }

    IEnumerator AmmoCoolDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(20);
            if (currentAmmo == null)
            {
                Debug.Log("Instantiating new Ammo...");
                currentAmmo = Instantiate(AmmoPrefab, AmmoSpawn.transform.position, Quaternion.identity);
            }
            else
            {
                Debug.Log("Ammo already exists...");
            }
        }
    }
}