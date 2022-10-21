using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 posNoZ = target.transform.position;
            posNoZ.z = -1;
            transform.position = posNoZ;
        }
    }
}
