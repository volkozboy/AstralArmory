using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Spawner;

public class TankSelection : MonoBehaviour
{
    public void TankSelected(){
        FindObjectOfType<SpawnManager>().TankSpawning();
    }
}
