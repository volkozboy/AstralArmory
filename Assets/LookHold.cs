using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookHold : MonoBehaviour
{
    public Transform lookPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = lookPos.position;
    }
}
