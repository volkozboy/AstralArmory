using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpark : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Bullet(gameObject));
    }

    // Update is called once per frame
   IEnumerator Bullet(GameObject Spark){
        yield return new WaitForSeconds(0.3f);
        Destroy(Spark);
    }
}
