using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Spawner;

public class SupportSelection : MonoBehaviour
{
    public void SupportSelected(){
        FindObjectOfType<SpawnManager>().SupportSpawning();
    }
}