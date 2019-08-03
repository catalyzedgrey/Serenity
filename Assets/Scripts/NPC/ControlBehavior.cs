using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMovement : MonoBehaviour, IInteractable
{
    public float speed = 6f;
    protected Vector3 movement;
    protected Quaternion lastRot;
    protected Rigidbody playerRigidbody;
    protected bool isMoving = false, isMoveEnabled;
    public CameraFollow cameraFollow;

    public Fungus.Flowchart fungusBlock;

    public PlayerMovement playerMovement;

    protected bool isWithinBounds, isBeingControlled, isControllable;



    // Start is called before the first frame update
    void Start()
    {
        isWithinBounds = false;
        isBeingControlled = false;
        isMoveEnabled = false;
        lastRot = this.transform.rotation;
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoveEnabled)
        {
            // Store the input axes.
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            float y = Input.GetAxis("Orthogonal");

            if (playerRigidbody == null)
                playerRigidbody = GetComponent<Rigidbody>();
            // Move the player around the scene.
            Move(h, v, y);


            // Turn the player to face the mouse cursor.
            Turning(h, v);


        }
    }

    //void Move(float h, float v)
    //{
    //    if (h != 0 || v != 0)
    //    {
    //        print("h: " + h);
    //        print("v: " + v);
    //        isMoving = true;
    //    }
    //    else
    //        isMoving = false;

    //    print("h: " + h);
    //    print("v: " + v);


    //    if(Input.GetKeyDown(KeyCode.LeftShift))
    //    {
    //        this.playerRigidbody.constraints = RigidbodyConstraints.None;
    //    }else
    //    {
    //        this.playerRigidbody.constraints = RigidbodyConstraints.FreezePositionY;
    //    }
    //    // Set the movement vector based on the axis input.
    //    this.movement = new Vector3(h, 0, v);
    //    this.movement = Quaternion.Euler(0, -45, 0) * movement;
    //    this.movement = movement.normalized;
    //    // Normalise the movement vector and make it proportional to the speed per second.


    //    this.movement *= speed * Time.deltaTime;



    //    //if(Input.GetKeyDown(KeyCode.D))// && !lookingRight)
    //    //{
    //    //    Quaternion newRotation = Quaternion.LookRotation(transform.right);
    //    //    print(transform.forward);
    //    //    playerRigidbody.MoveRotation(newRotation);
    //    //}

    //    this.movement = Camera.main.transform.TransformDirection(movement);
    //    // Move the player to it's current position plus the movement.
    //    playerRigidbody.MovePosition(transform.position + movement);

    //}

    void Move(float h, float v, float y)
    {
        if (h != 0)
        {
            print("h: " + h);
            print("v: " + v);
            isMoving = true;
            this.playerRigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }
        if( v != 0)
        {
            isMoving = true;
            this.playerRigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;
        }
        if( y != 0)
        {
            isMoving = true;
            this.playerRigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        }
        if (h ==0 && v ==0 && y ==0)
        {
            isMoving = false;
            this.playerRigidbody.constraints =
                RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ |
                RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }
        // Set the movement vector based on the axis input.
        this.movement = new Vector3(h, y, v);
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
        //    lastRot = Quaternion.Euler(new Vector3(0,  0, 0));

        //}


        if ((v == 1 || v > 0) && h == 0) //w
        {
            lastRot = Quaternion.Euler(new Vector3(0,  0, 0));

        }
        else if ((v == -1 || v < 0) && h == 0) //s
        {
            lastRot = Quaternion.Euler(new Vector3(0,  180, 0));

        }
        else if ((h == 1 || h > 0) && v == 0) //d
        {
            lastRot = Quaternion.Euler(new Vector3(0,  90, 0));

        }
        else if ((h == -1 || h < 0) && v == 0) //a
        {
            lastRot = Quaternion.Euler(new Vector3(0,  -90, 0));

        }
        else if (v > 0 && h > 0) // w & d
        {
            lastRot = Quaternion.Euler(new Vector3(0,  45, 0));
            //float angle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
            //angle = Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Mathf.Rad2Deg;
            //lastRot = Quaternion.Euler(new Vector3(0,  angle, 0));
        }
        else if (v > 0 && h < 0) // w & a
        {
            lastRot = Quaternion.Euler(new Vector3(0,  -45, 0));
            //float angle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
            //angle = Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Mathf.Rad2Deg;
            //lastRot = Quaternion.Euler(new Vector3(0,  angle, 0));
        }
        else if (v < 0 && h > 0) // s & d
        {
            lastRot = Quaternion.Euler(new Vector3(0,  135, 0));
            //float angle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
            //angle = Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Mathf.Rad2Deg;
            //lastRot = Quaternion.Euler(new Vector3(0,  angle, 0));
        }
        else if (v < 0 && h < 0) //s & a
        {
            lastRot = Quaternion.Euler(new Vector3(0,  225, 0));
            //float angle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
            //angle = Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Mathf.Rad2Deg;
            //lastRot = Quaternion.Euler(new Vector3(0,  angle, 0));
        }


        playerRigidbody.MoveRotation(lastRot);




    }

    public void Interact()
    {
        if(isControllable)
        {
            this.isMoveEnabled = true;
            this.isBeingControlled = true;
            this.playerMovement.DisableMovement();
            this.cameraFollow.SetTarget(this.transform, false);
        }
        
    }

    public void StopControl()
    {
        this.isMoveEnabled = false;
        this.isBeingControlled = false;
        this.playerMovement.EnableMovement();
        this.cameraFollow.SetTarget(playerMovement.transform, true);
    }

    public void SetControllable(bool isControllable)
    {
        this.isControllable = isControllable;
    }

    public void SetBeingControlled(bool isBeingControlled)
    {
        this.isBeingControlled = isBeingControlled;
    }
}
