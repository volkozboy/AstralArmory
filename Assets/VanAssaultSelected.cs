using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Spawner;

public class VanAssaultSelected : MonoBehaviour
{
    public void VangaurdAssaultSelected(){
        FindObjectOfType<SpawnManager>().VanguardAssaultSpawning();
    }
}

