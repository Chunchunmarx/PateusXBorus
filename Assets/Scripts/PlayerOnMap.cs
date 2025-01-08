using UnityEngine;

public class PlayerOnMap : MonoBehaviour
{
    public float rayDistance = 10f; 
    public float directionThreshold = 0.7f; 
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            Teleport(Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Teleport(Vector3.down);
        }
        else if (Input.GetKeyDown(KeyCode.A)) 
        {
            Teleport(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.D)) 
        {
            Teleport(Vector3.right);
        }
    }

    void Teleport(Vector3 direction)
    {
       
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        GameObject closestObject = null;
        float closestDistance = Mathf.Infinity;

        foreach (var obj in allObjects)
        {
          
            if (obj == this.gameObject) continue;

            Vector3 toObject = obj.transform.position - transform.position;

            
            if (Vector3.Dot(toObject.normalized, direction) > directionThreshold)
            {
                float distance = toObject.magnitude;

                
                if (distance < closestDistance && distance <= rayDistance)
                {
                    closestDistance = distance;
                    closestObject = obj;
                }
            }
        }

        
        if (closestObject != null)
        {
            transform.position = closestObject.transform.position;
            Debug.Log($"Teleported to {closestObject.name}");
        }
        else
        {
            Debug.Log("No teleportable object in the direction.");
        }
    }
}