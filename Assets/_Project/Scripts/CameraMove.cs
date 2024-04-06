using System.Collections;
using System.Collections.Generic;
using Play;
using UnityEngine;
using Photon.Pun;


public class CameraMove : MonoBehaviour
{
    public float MouseSense = 900.0f;
    public Transform playerbody;
    float xRotation = 0f;
   
    PhotonView view;
    public GameObject playerCanvas;
    public GameObject settingsMenu;

    public bool Dashing;

    public float bobbingSpeed = 10f; // Speed of the head bobbing
    public float bobbingAmount = 0.3f; // Amount of head bobbing
    

    private float timer = 0.0f;
    private Vector3 originalPosition;

    Animator anim;

    public void Start()
    {
        view = GetComponent<PhotonView>();
        anim = GetComponent<Animator>();
        
        if(view.IsMine){
            originalPosition = transform.localPosition;

            playerCanvas = GameObject.FindWithTag("Canvas"); 
            
            playerCanvas.gameObject.SetActive(false);

            Application.targetFrameRate = 60;

            
        }

    }

    
    public void Update()
    {
        if(view.IsMine){

           
            if(Input.GetKeyDown(KeyCode.Escape)){
                settingsMenu.SetActive(true);
            }
            if(Input.GetKeyUp(KeyCode.Escape)){
                settingsMenu.SetActive(false);
            }
       float MouseX = Input.GetAxis("Mouse X") * MouseSense * Time.deltaTime;
       float MouseY = Input.GetAxis("Mouse Y") * MouseSense * Time.deltaTime;

       xRotation -= MouseY;
       xRotation = Mathf.Clamp(xRotation, -60f, 60f);
       
       transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
       
       playerbody.Rotate(Vector3.up * MouseX);

        //Dashing Activate
       if(Input.GetKeyDown(KeyCode.LeftShift)){
            Dashing = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            Dashing = false;
        }


        //Head Bob
       if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f || Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f)
        {
            // Calculate head bob position based on a sine wave
            float bobbingY = Mathf.Sin(timer) * bobbingAmount;

            // Apply head bobbing to the camera's local position (vertical only)
            transform.localPosition = new Vector3(originalPosition.x, originalPosition.y + bobbingY, originalPosition.z);

            // Increase the timer based on the speed
            timer += bobbingSpeed * Time.deltaTime;
        }
        else
        {
            // Reset head bobbing when standing still
            timer = 0.0f;
            transform.localPosition = originalPosition;
        }
            
        }
    }

    public void DashRight(){
        anim.Play("CameraDashRight");
    }
    
    public void DashLeft(){
        anim.Play("CameraDashLeft");
    }
}


