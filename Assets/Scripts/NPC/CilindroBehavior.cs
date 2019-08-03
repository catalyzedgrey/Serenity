using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CilindroBehavior : ControlMovement, IInteractable
{
    //Vector3 movement;
    //Quaternion lastRot;
    //Rigidbody playerRigidbody;
    //bool isMoving = false, isMoveEnabled = false;

    //bool isWithinBounds, isBeingControlled = false;



    // Start is called before the first frame update
    void Start()
    {
        isWithinBounds = false;
        lastRot = this.transform.rotation;
        playerRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        if (this.isWithinBounds && Input.GetKey(KeyCode.E))
        {
            Interact();
        }

        //floatingHeight = 0.5f;
        ////get the objects current position and put it in a variable so we can access it later with less code

        ////calculate what the new Y position will be
        //float newY = Mathf.Sin(Time.time * speed) * floatingHeight + originalPos.y;
        ////set the object's Y to the new calculated Y
        //transform.position = new Vector3(originalPos.x, newY, originalPos.z);
    }

    void FixedUpdate()
    {
        if (isMoveEnabled && isBeingControlled)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            // Store the input axes.
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            // Move the player around the scene.
            Move(h, v);


            // Turn the player to face the mouse cursor.
            Turning(h, v);


        }
    }

    void Move(float h, float v)
    {
        if (h != 0 || v != 0)
            isMoving = true;
        else
            isMoving = false;


        // Set the movement vector based on the axis input.
        this.movement = new Vector3(h, 0, v);
        this.movement = Quaternion.Euler(0, -45, 0) * movement;
        this.movement = movement.normalized;
        // Normalise the movement vector and make it proportional to the speed per second.


        this.movement *= speed * Time.deltaTime;



        //if(Input.GetKeyDown(KeyCode.D))// && !lookingRight)
        //{
        //    Quaternion newRotation = Quaternion.LookRotation(transform.right);
        //    print(transform.forward);
        //    playerRigidbody.MoveRotation(newRotation);
        //}

        this.movement = Camera.main.transform.TransformDirection(movement);
        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);

    }







    void Turning(float h, float v)
    {

        //print("h: " + h);
        //print("v: " + v);


        //if (v == 0 && h == 0) 
        //{
        //    lastRot = Quaternion.Euler(new Vector3(-90, 0, 0));

        //}


            if ((v == 1 || v > 0) && h == 0) //w
            {
                lastRot = Quaternion.Euler(new Vector3(-90, 0, 0));

            }
            else if ((v == -1 || v < 0) && h == 0) //s
            {
                lastRot = Quaternion.Euler(new Vector3(-90, 180, 0));

            }
            else if ((h == 1 || h > 0) && v == 0) //d
            {
                lastRot = Quaternion.Euler(new Vector3(-90, 90, 0));

            }
            else if ((h == -1 || h < 0) && v == 0) //a
            {
                lastRot = Quaternion.Euler(new Vector3(-90, -90, 0));

            }
            else if (v > 0 && h > 0) // w & d
            {
                lastRot = Quaternion.Euler(new Vector3(-90, 45, 0));
                //float angle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
                //angle = Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Mathf.Rad2Deg;
                //lastRot = Quaternion.Euler(new Vector3(-90, angle, 0));
            }
            else if (v > 0 && h < 0) // w & a
            {
                lastRot = Quaternion.Euler(new Vector3(-90, -45, 0));
                //float angle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
                //angle = Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Mathf.Rad2Deg;
                //lastRot = Quaternion.Euler(new Vector3(-90, angle, 0));
            }
            else if (v < 0 && h > 0) // s & d
            {
                lastRot = Quaternion.Euler(new Vector3(-90, 135, 0));
                //float angle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
                //angle = Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Mathf.Rad2Deg;
                //lastRot = Quaternion.Euler(new Vector3(-90, angle, 0));
            }
            else if (v < 0 && h < 0) //s & a
            {
                lastRot = Quaternion.Euler(new Vector3(-90, 225, 0));
                //float angle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
                //angle = Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Mathf.Rad2Deg;
                //lastRot = Quaternion.Euler(new Vector3(-90, angle, 0));
            }


            playerRigidbody.MoveRotation(lastRot);
        



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            this.isWithinBounds = true;

    }

    //public void Interact()
    //{

    //    this.playerRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
    //    this.isMoveEnabled = true;
    //    this.isBeingControlled = true;
    //    this.playerMovement.DisableMovement();
    //    this.cameraFollow.SetTarget(this.transform, false);
    //}

    public void Die()
    {
        isMoveEnabled = false;
        fungusBlock.SendFungusMessage("Flash");
        cameraFollow.SetTarget(playerMovement.gameObject.transform, true);
        playerMovement.EnableMovement();
        this.GetComponent<Renderer>().enabled = false;
        this.transform.gameObject.SetActive(false);
        Destroy(this);
    }

}
