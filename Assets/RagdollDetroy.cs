using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollDetroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyRagdolls());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestroyRagdolls(){
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
