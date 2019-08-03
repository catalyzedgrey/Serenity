using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour, IInteractable, ITimeScalable
{
    public SpriteInteract interactableSprite;
    public Animator animator;
    bool isWithinBounds = false;
    

    // Use this for initialization
    void Start()
    {
        GameHandler.interfaceScripts.Add(this);
    }

    private void FixedUpdate()
    {
        Interact();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Equals("Player"))
        {
            isWithinBounds = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            isWithinBounds = false;
        }
    }

    public void Interact()
    {

            if (isWithinBounds && Input.GetKeyDown(KeyCode.E))
            {
                animator.SetBool("IsWithinBounds", true);
            }
            else if (!isWithinBounds)
            {
                animator.SetBool("IsWithinBounds", false);
            }

    }

    void ITimeScalable.SlowDown()
    {
        if(animator != null)
            animator.speed = GameHandler.slowdownFactor;
    }

    void ITimeScalable.ResetSpeed()
    {
        if (animator != null)
            animator.speed = 3f;
    }

}
