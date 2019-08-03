using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{



    public float floatingSpeed;
    //adjust this to change how high it goes
    public float floatingHeight;

    Vector3 origPos;
    public Vector3 newPos;

    public int axis;
    public float offset;
    public string mode;
    public float movementScale;

    public bool isEnabled;
    // Start is called before the first frame update
    void Start()
    {
        origPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnabled)
            Move();

        
    }

    private void Move()
    {
        if (mode.Equals("PointToOffset"))
        {
            switch (axis)
            {
                //x
                case 0:
                    this.transform.position = Vector3.MoveTowards(
                    this.transform.position,
                    new Vector3(origPos.x + offset,
                    origPos.y,
                    origPos.z),
                    Time.deltaTime * movementScale * GameHandler.slowdownFactor);
                    break;
                //y
                case 1:
                    this.transform.position = Vector3.MoveTowards(
                    this.transform.position,
                    new Vector3(origPos.x,
                    origPos.y + offset,
                    origPos.z),
                    Time.deltaTime * movementScale * GameHandler.slowdownFactor);
                    break;
                //z
                case 2:
                    this.transform.position = Vector3.MoveTowards(
                    this.transform.position,
                    new Vector3(origPos.x,
                    origPos.y,
                    origPos.z + offset),
                    Time.deltaTime * movementScale * GameHandler.slowdownFactor);
                    break;
            }


        }
        else if (mode.Equals("PointToPoint"))
        {
            this.transform.position = Vector3.MoveTowards(
                     this.transform.position,
                     newPos,
                     Time.deltaTime * movementScale * GameHandler.slowdownFactor);

        }
        else if (mode.Equals("BackAndForth"))
        {
            switch (axis)
            {
                //x
                case 0:
                    float newX = Mathf.Sin(Time.time * floatingSpeed) * floatingHeight + origPos.x;
                    transform.position = new Vector3(newX, origPos.y, origPos.z);
                    break;
                //y
                case 1:
                    float newY = Mathf.Sin(Time.time * floatingSpeed) * floatingHeight + origPos.y;
                    transform.position = new Vector3(this.transform.position.x, newY, this.transform.position.z);
                    break;
                //z
                case 2:
                    float newZ = Mathf.Sin(Time.time * floatingSpeed) * floatingHeight + origPos.z;
                    transform.position = new Vector3(origPos.x, origPos.y, newZ);
                    break;
            }
        }

    }
    public void SetEnabled(bool isEnabled)
    {
        this.isEnabled = isEnabled;
    }
}
