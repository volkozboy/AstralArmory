using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Play;

public class Sensitivity : MonoBehaviour
{
    Slider sliderr;
    public float sense;
    

    // Start is called before the first frame update
    void Start()
    {
        sliderr = GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {
            sense = sliderr.value; // Update the sense value
        
    }
}