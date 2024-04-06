using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movetoend : MonoBehaviour
{
    public GameObject endPoint;
    public GameObject startPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPoint.transform.position, 50 * Time.deltaTime);
        if(transform.position == endPoint.transform.position){
            transform.position = startPoint.transform.position;
        }
    }
}
