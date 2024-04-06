using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class post : MonoBehaviour
{
    public GameObject PostProcess;
    public Toggle toggle;
    public void Start(){
        toggle = GetComponent<Toggle>();
    }

    public void Update(){
        if(toggle.isOn){
            PostProcess.SetActive(false);
        }
            if(!toggle.isOn){
                PostProcess.SetActive(true);
            }
    }
}
