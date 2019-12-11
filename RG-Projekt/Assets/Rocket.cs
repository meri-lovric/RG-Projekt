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
        Rotate();
        Thrust();

    }
    private void Rotate()
    {
        rigidBody.freezeRotation = true; // take manual control of rotation
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward);
        }
        rigidBody.freezeRotation = false; // resume Physx control of rotation

    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        { //can thrust while rotating
            thrusting = true;
            rigidBody.AddRelativeForce(Vector3.up);

            if (thrusting && !thrustSound.isPlaying) // so the audio doesn't layer
            {
                thrustSound.Play();
            }

        }
        else
        {
            thrustSound.Stop();
        }
    }
}
