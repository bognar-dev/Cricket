using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform aimTarget; // the target where we aim to land the ball
    public float speed = 3f; // move speed
    public float force = 13; // ball impact force
    public float hittingAngle = 10;
    bool hitting; // boolean to know if we are hitting the ball or not 

    public Transform ball; // the ball 

    private Vector3 aimTargetInitialPosition;
    // Start is called before the first frame update
    void Start()
    {
        aimTargetInitialPosition = aimTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal"); // get the horizontal axis of the keyboard
        float verticalMovement = - Input.GetAxisRaw("Vertical"); // get the vertical axis of the keyboard

        if (Input.GetKeyDown(KeyCode.F)) 
        {
            hitting = true; // we are trying to hit the ball and aim where to make it land
           
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            hitting = false; // we let go of the key so we are not hitting anymore and this 
        }                    // is used to alternate between moving the aim target and ourself

        if (Input.GetKeyDown(KeyCode.E))
        {
            hitting = true; // we are trying to hit the ball and aim where to make it land
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            hitting = false;
        }



        if (hitting)  // if we are trying to hit the ball
        {
            aimTarget.Translate(new Vector3(horizontalMovement, 0, 0) * (speed * 2 * Time.deltaTime)); 
        }


        if ((horizontalMovement != 0 || verticalMovement != 0) && !hitting) // if we want to move and we are not hitting the ball
        {
            transform.Translate(new Vector3(verticalMovement, 0, horizontalMovement) * (speed * Time.deltaTime));
        }



    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) // if we collide with the ball 
        {
            Vector3 dir = aimTarget.position - transform.position; // get the direction to where we want to send the ball
            other.GetComponent<Rigidbody>().velocity = dir.normalized  + new Vector3(0, hittingAngle, speed);
            //add force to the ball plus some upward force according to the shot being played
            
           
            aimTarget.position = aimTargetInitialPosition; // reset the position of the aiming gameObject to it's original position ( center)

        }
    }


}
