using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Spawner;

public class VanSupportSelected : MonoBehaviour
{
    public void VangaurdSupportSelected(){
        FindObjectOfType<SpawnManager>().VanguardSupportSpawning();
    }
}
