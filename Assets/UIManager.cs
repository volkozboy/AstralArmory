using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject canvasPrefab;

    private GameObject playerCanvas;

    private void Start()
    {
        // Instantiate the canvas prefab for this player
        playerCanvas = Instantiate(canvasPrefab, transform.position, transform.rotation, transform);
    }

    // Other methods for updating the UI as needed
}