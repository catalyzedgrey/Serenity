using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackForthMovement : MonoBehaviour
{

    public float speed;
    public float offset;
    public string axis;

    Vector3 origPos;
    // Start is called before the first frame update
    void Start()
    {
        origPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (axis)
        {

            //x
            case "x":
                float newX = Mathf.Sin(Time.time * speed) * offset + origPos.x;
                transform.position = new Vector3(newX, origPos.y, origPos.z);
                break;
            //y
            case "y":
                float newY = Mathf.Sin(Time.time * speed) * offset + origPos.y;
                transform.position = new Vector3(this.transform.position.x, newY, this.transform.position.z);
                break;
            //z
            case "z":
                float newZ = Mathf.Sin(Time.time * speed) * offset + origPos.z;
                transform.position = new Vector3(origPos.x, origPos.y, newZ);
                break;

        }
        
    }
}
