using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFenceBehavior : MonoBehaviour, IInteractable
{
    Renderer[] rendererChildren;
    BoxCollider boxCollider;
    bool isBot = false;
    // Start is called before the first frame update

    void Start()
    {
        rendererChildren = GetComponentsInChildren<Renderer>();
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Interact()
    {
        foreach (Renderer r in rendererChildren)
        {
            if (isBot && r.gameObject.name.Contains("Laser"))
                r.enabled = false;
            else
                r.material.SetColor("_EmissionColor", new Color(0, 0, 0));
            
        }
        boxCollider.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Bot") && collision.gameObject.name.Contains("Cilindro"))
        {
            isBot = true;
            CilindroBehavior cil = (CilindroBehavior)collision.gameObject.GetComponent<CilindroBehavior>();
            cil.Die();
            Interact();
        }else if(collision.gameObject.tag.Equals("Bot") && collision.gameObject.name.Contains("drg"))
        {
            isBot = true;
            DrgBehavior drgBehavior = (DrgBehavior)collision.gameObject.GetComponent<DrgBehavior>();
            drgBehavior.Die();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Bot"))
            isBot = false;
    }


}
