using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float time = 3f;
    private void Start()
    {
        Destroy(gameObject, time);
    }
}
