using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolToCamera : MonoBehaviour
{
    public Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cam.transform.position;
    }
}
