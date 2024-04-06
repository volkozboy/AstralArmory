using UnityEngine;
using Photon.Pun;

public class CameraUI : MonoBehaviour
{
    public GameObject cameraPrefab; // Reference to the camera prefab

    private void Start()
    {
        // Only spawn a camera for the local player when joining
        if (PhotonNetwork.IsConnectedAndReady && PhotonNetwork.IsMasterClient)
        {
            SpawnCamera();
        }
    }

    private void SpawnCamera()
    {
        GameObject spawnedCamera = PhotonNetwork.Instantiate(cameraPrefab.name, transform.position, transform.rotation);
        spawnedCamera.GetComponent<Camera>().enabled = true; // Enable the camera for the local player
    }
}