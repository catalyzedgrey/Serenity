using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinkerBehavior : MonoBehaviour
{

    //public GameObject toPt1;
    //public GameObject toPt2;

    private float toPt1, toPt2, toPt3;

    bool isFirstTriggerFired = false;
    bool isSecondTriggerFired = false;

    int sequenceNum = 0;
    DialogueInteract dialogue;

    public GameObject toPt4, lookAtPt;

    // Start is called before the first frame update
    void Start()
    {
        toPt1 = this.transform.position.x + 13;
        toPt2 = this.transform.position.z + 4;
        toPt3 = this.transform.position.x + 6;
        //toPt4 = this.transform.Find("pt4").gameObject;

        dialogue = GetComponent<DialogueInteract>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (isFirstTriggerFired)
        //{
        //    if (this.transform.position.x < toPt1)
        //    {
        //        this.transform.position = Vector3.MoveTowards(this.transform.position,
        //                    new Vector3(toPt1,
        //                    this.transform.position.y,
        //                    this.transform.position.z), Time.deltaTime * 5);
        //    }

        //    if (this.transform.position.x >= toPt1 && toPt2 >= this.transform.position.z)
        //    {
        //        this.transform.rotation = Quaternion.Euler(new Vector3(0, -45, 0));

        //        this.transform.position = Vector3.MoveTowards(this.transform.position,
        //                    new Vector3(this.transform.position.x,
        //                    this.transform.position.y,
        //                    toPt2), Time.deltaTime * 5);
        //    }

        //    if (toPt2 == this.transform.position.z)
        //    {
        //        this.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        //        dialogue.Interact();
        //    }
        //}

        if (sequenceNum == 1)
        {
            if (this.transform.position.x < toPt1)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position,
                            new Vector3(toPt1,
                            this.transform.position.y,
                            this.transform.position.z), Time.deltaTime * 5);
            }

            if (this.transform.position.x >= toPt1 && toPt2 >= this.transform.position.z)
            {
                this.transform.rotation = Quaternion.Euler(new Vector3(0, -45, 0));

                this.transform.position = Vector3.MoveTowards(this.transform.position,
                            new Vector3(this.transform.position.x,
                            this.transform.position.y,
                            toPt2), Time.deltaTime * 5);
            }

            if (toPt2 == this.transform.position.z)
            {
                this.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
                dialogue.Interact();
                sequenceNum = 0;
                toPt1 = this.transform.position.x - 12;
                toPt2 = this.transform.position.z - 3;
            }
        }
        else if (sequenceNum == 2)
        {

            if (this.transform.position.z > toPt2)
            {
                this.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                this.transform.position = Vector3.MoveTowards(this.transform.position,
                            new Vector3(this.transform.position.x,
                            this.transform.position.y,
                            toPt2), Time.deltaTime * 5);
            }
            if (this.transform.position.z == toPt2)
            {
                this.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
                this.transform.position = Vector3.MoveTowards(this.transform.position,
                            new Vector3(toPt3,
                            this.transform.position.y,
                            this.transform.position.z), Time.deltaTime * 5);
            }
            if (this.transform.position.x == toPt3)
            {
                this.transform.rotation = Quaternion.Euler(new Vector3(0, -180, 0));
                TriggerInteractionSequence(3);

            }

            //if (this.transform.position.x >= toPt1 && toPt2 >= this.transform.position.z)
            //{
            //    this.transform.rotation = Quaternion.Euler(new Vector3(0, -45, 0));

            //    this.transform.position = Vector3.MoveTowards(this.transform.position,
            //                new Vector3(this.transform.position.x,
            //                this.transform.position.y,
            //                toPt2), Time.deltaTime * 5);
            //}


        }
        else if (sequenceNum == 3)
        {
            
            this.transform.LookAt(lookAtPt.transform);
                this.transform.position = Vector3.MoveTowards(this.transform.position,
                                new Vector3(toPt4.transform.position.x, this.transform.position.y, toPt4.transform.position.z), Time.deltaTime * 5);
        }


    }

    public void TriggerInteractionSequence(int sequenceNum)
    {
        //isFirstTriggerFired = true;

        this.sequenceNum = sequenceNum;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
    }
}


