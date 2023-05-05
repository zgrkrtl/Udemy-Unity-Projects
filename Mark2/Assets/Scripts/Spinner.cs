using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float xCoord = 0;
    [SerializeField] float yCoord = 0;
    [SerializeField] float zCoord = 0;

    void Update()
    {
        transform.Rotate(xCoord, yCoord, zCoord);
    }
}
