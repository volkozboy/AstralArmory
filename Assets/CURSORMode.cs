using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Play;
using UnityEngine.UI;

public class CURSORMode : MonoBehaviour
{
    public Camera mainCam;
    public bool Camactive;

    PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}