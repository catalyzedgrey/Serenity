using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrgBehavior : ControlMovement
{
    Animator animator;
    Vector3 origPos;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        origPos = transform.position;
        isControllable = true;

    }

    // Update is called once per frame
    void Update()
    {

    }

    new void Interact()
    {
        base.Interact();
        if (animator != null)
            animator.SetBool("IsBeingControlled", true);
    }

    public void Die()
    {
        this.enabled = false;
        this.transform.position = origPos;
        this.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Die();
        }
    }
}
