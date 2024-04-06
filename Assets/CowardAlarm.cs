using UnityEngine;

public class CowardAlarm : MonoBehaviour
{
    public LayerMask detectionLayer; // Assign the detection layer in the Inspector
    public float idleTimeThreshold = 0.25f; // Adjust this value to set the idle time threshold
    public float idleTimer = 0f;
    public bool isObjectInside = false;

    void Update()
    {
        if (isObjectInside)
        {
            idleTimer += Time.deltaTime;
            if (idleTimer >= idleTimeThreshold)
            {
                PerformIdleAction();
            }
        }
    }

    void PerformIdleAction()
    {
        Debug.Log("COWARD!");
    }

    void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, transform.localScale.x / 0.25f, detectionLayer); 
        if (colliders.Length > 0)
        {
            isObjectInside = true;
        }
        else
        {
            isObjectInside = false; 
            idleTimer = 0f; 
        }
    }

    void OnDrawGizmos()
    {
        
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, transform.localScale.x / 0.25f); 
    }
}
