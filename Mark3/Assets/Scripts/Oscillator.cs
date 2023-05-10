using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 sp;
    [SerializeField] Vector3 mv;
    float mf;
    [SerializeField] float period = 2f;
    void Start()
    {
        sp = transform.position;
        Debug.Log(sp);
    }
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);
        mf = (rawSinWave + 1f) / 2f;
        Vector3 offset = mv * mf;
        transform.position = sp + offset;
    }
}
