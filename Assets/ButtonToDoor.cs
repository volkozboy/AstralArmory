using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonToDoor : MonoBehaviour
{
    public GameObject Door;
bool isClickedButton;

public Transform ButtonCheck;
public float buttonDistance = 1f;
public LayerMask PlayerMask;

private bool DoorClosed = true;  // Start with the door closed

void Update()
{
    isClickedButton = Physics.CheckSphere(ButtonCheck.position, buttonDistance, PlayerMask);
    
    if (isClickedButton && Input.GetKeyDown(KeyCode.E))
    {
        // Toggle the DoorClosed state
        DoorClosed = !DoorClosed;
        
        // Set the door's active state based on DoorClosed
        Door.SetActive(!DoorClosed);
    }
}

void OnDrawGizmosSelected()
{
    // Draw a yellow wire sphere at the transform's position
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireSphere(ButtonCheck.position, buttonDistance);
}
    
}
