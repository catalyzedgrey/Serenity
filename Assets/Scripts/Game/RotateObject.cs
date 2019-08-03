using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour, ITimeScalable
{
    bool isSlowedDown = false;
    public string direction;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        GameHandler.interfaceScripts.Add(this);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch(direction)
        {
            case "up":
                transform.Rotate(Vector3.up, speed * Time.deltaTime * GameHandler.slowdownFactor);
                break;

            case "right":
                transform.Rotate(Vector3.right, speed * Time.deltaTime * GameHandler.slowdownFactor);
                break;
        }
        

    }

    void ITimeScalable.SlowDown()
    {
        isSlowedDown = true;
    }

    void ITimeScalable.ResetSpeed()
    {
        isSlowedDown = false;
    }
}
