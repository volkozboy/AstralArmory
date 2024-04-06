using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKitSpawn : MonoBehaviour
{
    public GameObject MedKitPrefab;
    public GameObject MedSpawn;

    private GameObject currentMedKit;

    void Start()
    {
        StartCoroutine(MedCoolDown());
    }

    IEnumerator MedCoolDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(20);
            if (currentMedKit == null)
            {
                Debug.Log("Instantiating new MedKit...");
                currentMedKit = Instantiate(MedKitPrefab, MedSpawn.transform.position, Quaternion.identity);
            }
            else
            {
                Debug.Log("MedKit already exists...");
            }
        }
    }
}
