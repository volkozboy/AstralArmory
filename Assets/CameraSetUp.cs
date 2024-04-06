using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetUp : MonoBehaviour
{
    public GameObject UICam;
    // Start is called before the first frame update
    void Start()
    {
        UICam = GameObject.FindWithTag("UICamera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
