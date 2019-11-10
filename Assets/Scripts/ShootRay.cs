using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRay : MonoBehaviour
{
    public static ShootRay instance;
    public GameObject ProjectedAnchor;
    public Vector3 projectedPosition;
    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, Vector3.down * hit.distance, Color.yellow);
            ProjectedAnchor.transform.position = hit.point;
            //Debug.Log("Did Hit: "+hit.collider.name);
            projectedPosition = hit.point;
        }
        else
        {
            Debug.DrawRay(transform.position, Vector3.down * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }

}
