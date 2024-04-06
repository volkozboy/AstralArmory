using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Play;
public class MedKit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider colider){

        if(colider.transform.gameObject.GetComponent<Health>().health == colider.transform.gameObject.GetComponent<Health>().maxHealth){
            return;
        }
            colider.transform.gameObject.GetComponent<Health>().health += 50;
            Destroy(gameObject);
    }

}
