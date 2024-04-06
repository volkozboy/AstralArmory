using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Spawner;

public class AssaultSelection : MonoBehaviour
{
    public void AssaultSelected(){
        FindObjectOfType<SpawnManager>().AssaultSpawning();
    }
}
