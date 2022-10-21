using System;
using System.Collections;
using System.Collections.Generic;
// using System.Xml;
using System.Linq;
using UnityEngine;
public class GPull : MonoBehaviour
{
    private static double G = 6.674 * Math.Pow(10, -1);
    public Vector3 currentVelocity = new Vector3(0,0, 0);
    private GameObject[] objects = new GameObject[] {};

    private void updateVelocity(GameObject[] objList)
    {
        foreach (var obj in objList)
        {
            float sqrDist = (obj.GetComponent<Rigidbody>().position
                             - this.GetComponent<Rigidbody>().position).sqrMagnitude;
            Vector3 forceDir = obj.GetComponent<Rigidbody>().position
                               - this.GetComponent<Rigidbody>().position.normalized;
            Vector3 force = (forceDir *
                             (float)G *
                             obj.GetComponent<Rigidbody>().mass) /
                            sqrDist;
            currentVelocity = force;
        }
    }

    void Awake()
    {
        objects = GameObject.FindGameObjectsWithTag("HasMass");
        objects = objects.Except(new GameObject[] {this.gameObject}).ToArray();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateVelocity(objects);
        this.GetComponent<Rigidbody>().velocity = currentVelocity;
    }
}
