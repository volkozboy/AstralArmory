using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAGDOLlSpawn : MonoBehaviour
{
    public GameObject TankRagdoll;
    public GameObject AssaultRagdoll;
    public GameObject SupportRagdoll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            var random = Random.Range(1, 4);
            Debug.Log(random);

            if(random == 1){
                Instantiate(TankRagdoll, transform.position, Quaternion.identity);
            }
                if(random == 2){
                    Instantiate(AssaultRagdoll, transform.position, Quaternion.identity);
                }
                    if(random == 3){
                        Instantiate(SupportRagdoll, transform.position, Quaternion.identity);
                    }
        }
    }
}
