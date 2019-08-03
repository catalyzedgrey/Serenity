using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovement : MonoBehaviour, ITimeScalable
{
    public GameObject player;
    private Animator animator;
    
    public GameObject[] tiles;
    private bool triggerFirstTile = false;
    private bool isEnabled = true;
    // Use this for initialization
    void Start()
    {
        GameHandler.interfaceScripts.Add(this);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameHandler.lvl.Equals("2-2"))
        {
            //LayerMask layerMask = LayerMask.GetMask("Death Ground");

            int layer1 = 8;
            int layer2 = 9;
            int layermask1 = 1 << layer1;
            int layermask2 = 1 << layer2;
            int finalmask = layermask1 | layermask2; // Or, (1 << layer1) | (1 << layer2)

            //int layerMask = LayerMask.GetMask("Death Ground");
            //int 
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(player.transform.position, player.transform.TransformDirection(Vector3.down), out hit, 0.2f, finalmask))
            {
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("should be alive");
                Respawn.isDead = false;
                
            }
            else
            {
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Respawn.isDead = true;
                Debug.Log("should be dead");
            }
        }
    }

    void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    public void ResetSpeed()
    {
        animator.speed = 1f;
    }

    public void SlowDown()
    {
        animator.speed = 0.15f;
    }

}
