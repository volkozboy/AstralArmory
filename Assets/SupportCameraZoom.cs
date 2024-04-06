using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Play;
public class SupportCameraZoom : MonoBehaviour
{
    public Camera cameraa;
    public GameObject Scope;
    public bool Sniper2;

    PhotonView view;
    void Start()
    {
        view = GetComponent<PhotonView>();
        cameraa = GetComponent<Camera>();
    }

    
    void Update()
    {
        if(!view.IsMine){
            return;
        }
        if(view.IsMine){
            if (Input.GetKeyDown(KeyCode.Alpha1)){
            Sniper2 = true;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            Sniper2 = false;
        }

            if(Input.GetButtonDown("Fire2") && Sniper2 == true){
                cameraa.fieldOfView = 10;
                Scope.SetActive(true);
                FindObjectOfType<CameraMove>().MouseSense = 150;
            }
                if(Input.GetButtonUp("Fire2") && Sniper2 == true){
                    cameraa.fieldOfView = 70;
                    Scope.SetActive(false);
                    FindObjectOfType<CameraMove>().MouseSense = FindObjectOfType<CameraMove>().MouseSense;
                }
        }
        
    }
}
