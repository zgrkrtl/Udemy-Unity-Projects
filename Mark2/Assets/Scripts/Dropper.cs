using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    MeshRenderer invis;
    Rigidbody gravity;
    [SerializeField] float TimetoWait = 5f;

    void Start()
    {
        invis = GetComponent<MeshRenderer>();
        invis.enabled = false;
        gravity = GetComponent<Rigidbody>();
        gravity.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > TimetoWait)
        {
            invis.enabled = true;
            gravity.useGravity = true;
        }
    }
}
