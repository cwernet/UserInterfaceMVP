using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatIcon : MonoBehaviour
{
    GameObject canoe;
    // Start is called before the first frame update
    void Start()
    {
        canoe = GameObject.FindGameObjectWithTag("Canoe");
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = canoe.transform.rotation;
    }
}
