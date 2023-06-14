using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector3 initialPos; // ball's initial position
    public GameObject wicket;
    public TrailRenderer trail;
    public float throwSpeed = 5f; // The speed of the throw in meters per second
    public float throwAngle = 1f; // The angle of the throw in degrees
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        initialPos = transform.position; // default it to where we first place it in the scene
        _rigidbody.isKinematic = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowBall();
        }
    }

    private void ThrowBall()
    {
        _rigidbody.isKinematic = false;
        Vector3 dir = wicket.transform.position -transform.position;
        // get the direction to where we want to send the ball
        _rigidbody.velocity = (dir.normalized * throwSpeed);
        Debug.Log(_rigidbody.velocity);
        //add force to the ball plus some upward force according to the shot being player
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Boundary")) // if the ball hits a wall
        {
            Debug.Log("Boundary");
            _rigidbody.velocity = Vector3.zero; // reset it's velocity to 0 so it doesn't move anymore
            transform.position = initialPos; // reset it's position 
            trail.Clear();
            _rigidbody.isKinematic = true;
        }
    }
}