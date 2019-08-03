using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptedDialogue : MonoBehaviour
{
    public Fungus.Flowchart fungusBlock;
    public string messageToSendFungus;
    bool fired = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!fired && messageToSendFungus != null && messageToSendFungus != "")
        {
            fungusBlock.SendFungusMessage(messageToSendFungus);
        }
        fired = true;  
    }
}
