using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource thrustSound;
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;


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
        float rotationThisFrame = rcsThrust * Time.deltaTime;
        rigidBody.freezeRotation = true; // take manual control of rotation
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }
        rigidBody.freezeRotation = false; // resume Physx control of rotation

    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        { //can thrust while rotating
            thrusting = true;
            rigidBody.AddRelativeForce(Vector3.up * mainThrust);

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

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("OK"); // todo remove
                break;
            default:
                print("Dead");
                //kill the player
                break;
        }
    }
}


