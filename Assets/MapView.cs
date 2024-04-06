using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapView : MonoBehaviour
{
    public Toggle FFA;
    public GameObject Maps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(FFA.isOn){
            Maps.SetActive(true);
        }
        if(!FFA.isOn){
            Maps.SetActive(false);
        }
    }
}
