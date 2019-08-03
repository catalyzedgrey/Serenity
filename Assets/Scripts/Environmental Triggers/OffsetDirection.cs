using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetDirection : MonoBehaviour
{
    private bool isActive = false;
    public float offset = 1.52f;
    public string axis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            switch(axis)
            {
                case "x":
                    this.transform.position = Vector3.MoveTowards(this.transform.position,
                       new Vector3(this.transform.position.x - offset, this.transform.position.y, this.transform.position.z), Time.deltaTime * 4);
                    break;

                case "y":
                    this.transform.position = Vector3.MoveTowards(this.transform.position,
                       new Vector3(this.transform.position.x, this.transform.position.y - offset, this.transform.position.z), Time.deltaTime * 4);
                    break;

                case "z":
                    this.transform.position = Vector3.MoveTowards(this.transform.position,
                       new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - offset), Time.deltaTime * 4);
                    break;
            }
           
        }
    }

    public void SetIsActiveTrue
        ()
    {
        this.isActive = true;
    }
}
