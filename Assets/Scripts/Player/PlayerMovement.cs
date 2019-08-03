using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;            // The speed that the player will move at.
    //public float t;
    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Animator anim;                      // Reference to the animator component.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    //int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    Quaternion lastRot = Quaternion.identity;
    bool isMoveEnabled = true;
    [SerializeField] Fungus.Flowchart lvlOneFungusBlock;
    bool DialogueCollider0 = true;
    bool DialogueCollider1 = true;
    bool isGoingUpStairs = false;

    [SerializeField] GameObject eve;

    CapsuleCollider capsuleCollider;

    bool isMoving = false;

    void Awake()
    {

        // Create a layer mask for the floor layer.
        //floorMask = LayerMask.GetMask("Floor");

        // Set up references.
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();

    }


    void FixedUpdate()
    {
        

        if (isMoveEnabled)
        {
            // Store the input axes.
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            // Move the player around the scene.
            Move(h, v);
            // Turn the player to face the mouse cursor.
            Turning(h, v);
            // Animate the player.
            Animating(h, v);
        }
    }

    void Move(float h, float v)
    {
        if (h != 0 || v != 0)
            isMoving = true;
        else 
            isMoving = false;

        // Set the movement vector based on the axis input.
        movement = new Vector3(h, 0, v);
        movement = Quaternion.Euler(0, -45, 0) * movement;
        movement = movement.normalized;
        // Normalise the movement vector and make it proportional to the speed per second.


        movement *= speed * Time.deltaTime;



        //if(Input.GetKeyDown(KeyCode.D))// && !lookingRight)
        //{
        //    Quaternion newRotation = Quaternion.LookRotation(transform.right);
        //    print(transform.forward);
        //    playerRigidbody.MoveRotation(newRotation);
        //}

        movement = Camera.main.transform.TransformDirection(movement);
        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);

        


    }

    void Turning(float h, float v)
    {

        //print("h: " + h);
        //print("v: " + v);


        if ((v == 1 || v > 0) && h == 0) //w
        {
            lastRot = Quaternion.Euler(new Vector3(0, 0, 0));

        }
        else if ((v == -1 || v < 0) && h == 0) //s
        {
            lastRot = Quaternion.Euler(new Vector3(0, 180, 0));

        }
        else if ((h == 1 || h > 0) && v == 0) //d
        {
            lastRot = Quaternion.Euler(new Vector3(0, 90, 0));

        }
        else if ((h == -1 || h < 0) && v == 0) //a
        {
            lastRot = Quaternion.Euler(new Vector3(0, -90, 0));

        }
        else if (v > 0 && h > 0) // w & d
        {
            lastRot = Quaternion.Euler(new Vector3(0, 45, 0));
            //float angle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
            //angle = Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Mathf.Rad2Deg;
            //lastRot = Quaternion.Euler(new Vector3(0, angle, 0));
        }
        else if (v > 0 && h < 0) // w & a
        {
            lastRot = Quaternion.Euler(new Vector3(0, -45, 0));
            //float angle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
            //angle = Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Mathf.Rad2Deg;
            //lastRot = Quaternion.Euler(new Vector3(0, angle, 0));
        }
        else if (v < 0 && h > 0) // s & d
        {
            lastRot = Quaternion.Euler(new Vector3(0, 135, 0));
            //float angle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
            //angle = Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Mathf.Rad2Deg;
            //lastRot = Quaternion.Euler(new Vector3(0, angle, 0));
        }
        else if (v < 0 && h < 0) //s & a
        {
            lastRot = Quaternion.Euler(new Vector3(0, 225, 0));
            //float angle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
            //angle = Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Mathf.Rad2Deg;
            //lastRot = Quaternion.Euler(new Vector3(0, angle, 0));
        }


        playerRigidbody.MoveRotation(lastRot);


    }

    void Animating(float h, float v)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool walking = h != 0f || v != 0f;

        // Tell the animator whether or not the player is walking.
        anim.SetBool("isWalking", walking);
    }

    public void EnableMovement()
    {
        isMoveEnabled = true;
        //anim.SetBool("isWalking", true);
    }

    public void DisableMovement()
    {
        isMoveEnabled = false;
        anim.SetBool("isWalking", false);
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name);
    }

  

    void SetEveVisible()
    {
        eve.GetComponent<Animator>().Play("HumanoidIdle");
        eve.SetActive(true);
    }

    void SetEveInvisible()
    {

        eve.SetActive(false);
    }

    void TriggerStandUpAnim()
    {

        anim.SetTrigger("StandUp");
        if (capsuleCollider != null)
            capsuleCollider.enabled = true;

    }

    void TriggerPainAnim()
    {
        anim.SetTrigger("InPain");
    }

    public void SetCapsuleCollider(bool isEnabled)
    {
        if(isEnabled)
        {
            GetComponent<CapsuleCollider>().enabled = true;
        }
        else
        {
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }

}