using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPoint : MonoBehaviour
{
    public Transform camPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(camPoint.position.x, camPoint.position.y, 1f);
    }
}
