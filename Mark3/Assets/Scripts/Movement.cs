using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Initializing GameComponent before using GetComponent<>
    Rigidbody rb;
    AudioSource asrc;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainEngineParticle;
    [SerializeField] ParticleSystem leftThrusterParticle;
    [SerializeField] ParticleSystem rightThrusterParticle;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        asrc = GetComponent<AudioSource>();
    }
    void Update()
    {
        ProcessThrusht();
        ProcessRotation();
    }

    void ProcessThrusht()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!asrc.isPlaying)
            {
                asrc.PlayOneShot(mainEngine);
            }
            if (!mainEngineParticle.isPlaying)
                mainEngineParticle.Play();
        }
        else
        {
            asrc.Stop();
            mainEngineParticle.Stop();
        }

    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
            if (!leftThrusterParticle.isPlaying)
                leftThrusterParticle.Play();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
            if (!rightThrusterParticle.isPlaying)
                rightThrusterParticle.Play();
        }
        else
        {
            leftThrusterParticle.Stop();
            rightThrusterParticle.Stop();
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        //Using freezeRotation to getting rid of  physics bugs in unity engine
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }

}
