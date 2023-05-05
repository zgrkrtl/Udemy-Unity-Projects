using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Felicity : MonoBehaviour
{
    [SerializeField] float Speed = 10.10f;

    void Start()
    {
        PrintInstructions();
    }
    void Update()
    {
        MovePlayer();
    }

    void PrintInstructions()
    {
        Debug.Log("Welcome adventurer!");
        Debug.Log("Move inputs W A S D");
        Debug.Log("Esc for quit");
    }
    void MovePlayer()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        float yValue = 0;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * Speed;
        transform.Translate(xValue, yValue, zValue);
    }
}
