using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector3 initialPos; // ball's initial position
    public TrailRenderer trail;
    private void Start()
    {
        initialPos = transform.position; // default it to where we first place it in the scene
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.transform.CompareTag("Boundary")) // if the ball hits a wall
        {
            Debug.Log("Boundary");
            GetComponent<Rigidbody>().velocity = Vector3.zero; // reset it's velocity to 0 so it doesn't move anymore
            transform.position = initialPos; // reset it's position 
            trail.Clear();
        }
    }

}