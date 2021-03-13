using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public bool followX, followY, followZ;
    public Transform objectToFollow;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 location = objectToFollow.position;
        if(!followX)
        {
            location.x = transform.position.x;
        }
        if (!followY)
        {
            location.y = transform.position.y;  
        }
        if (!followZ)
        {
            location.z = transform.position.z;
        }
        transform.position = location + offset;
    }
}
