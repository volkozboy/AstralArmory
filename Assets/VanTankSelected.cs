using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Spawner;

public class VanTankSelected : MonoBehaviour
{
    public void VangaurdTankSelected(){
        FindObjectOfType<SpawnManager>().VanguardTankSpawning();
    }
}