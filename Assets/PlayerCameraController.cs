using UnityEngine;
using Photon.Pun;

public class PlayerCameraController : MonoBehaviour
{
    // Reference to the PhotonView component
    private PhotonView photonView;

    void Start()
    {
        photonView = GetComponent<PhotonView>();

        // Only allow the local player's camera to render
        if (!photonView.IsMine)
        {
            DisableCamera();
        }
    }

    void DisableCamera()
    {
        // Disable camera rendering and audio listener for other players
        Camera camera = GetComponent<Camera>();
        if (camera != null)
        {
            camera.enabled = false;
            AudioListener audioListener = camera.GetComponent<AudioListener>();
            if (audioListener != null)
            {
                audioListener.enabled = false;
            }
        }
    }
}
