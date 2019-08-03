using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteract : MonoBehaviour, IInteractable
{
    SpriteInteract spriteInteract;
    public string messageToSendFungus;
    public Fungus.Flowchart fungusBlock;


    // Start is called before the first frame update
    void Start()
    {
        spriteInteract = GetComponent<SpriteInteract>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spriteInteract != null)
        {
            if (spriteInteract.getIsWithinBounds() && Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    public void SetMessage(string message)
    {
        this.messageToSendFungus = message;
    }

    public void Interact()
    {
        fungusBlock.SendFungusMessage(messageToSendFungus);
    }
}
