using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource thrustSound;
    bool thrusting = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        thrustSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }
    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        { //can thrust while rotating
            thrusting = true;
            rigidBody.AddRelativeForce(Vector3.up);

            if (thrusting && !thrustSound.isPlaying)
            {
                thrustSound.Play();
            }
        
        }
    else{
        thrustSound.Stop();
    }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
        }
    }
}
