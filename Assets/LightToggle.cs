using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightToggle : MonoBehaviour
{
    public GameObject Lights;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(lighting());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator lighting(){
        yield return new WaitForSeconds(2);
        Lights.SetActive(false);
        yield return new WaitForSeconds(2);
        Lights.SetActive(true);
    }
}
