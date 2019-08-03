using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeChild : MonoBehaviour
{
    
    public GameObject player;
    public GameObject parent;

    float speed = 2;

    Vector3 pointA;
    Vector3 pointB;


    // Use this for initialization
    void Start()
    {
        pointA = new Vector3(transform.position.x - 16.5f, transform.position.y, transform.position.z);
        pointB = new Vector3(transform.position.x + 16.5f, transform.position.y, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {

        pointA = new Vector3(20f, transform.position.y, transform.position.z);
        pointB = new Vector3(50f, transform.position.y, transform.position.z);
        //PingPong between 0 and 1
        if (this.name.Equals("Tile 0"))
        {
            float time = Mathf.PingPong(Time.time * 0.8f * speed * GameHandler.slowdownFactor, 1f);
            transform.position = Vector3.Lerp(pointA, pointB, time);
        }
        else if (this.name.Equals("Tile 1"))
        {
            float time = Mathf.PingPong(Time.time * 0.5f * speed * GameHandler.slowdownFactor, 1);
            transform.position = Vector3.Lerp(pointA, pointB, time);
        }
        else if (this.name.Equals("Tile 2"))
        {
            float time = Mathf.PingPong(Time.time * 0.2f * speed * GameHandler.slowdownFactor, 1);
            transform.position = Vector3.Lerp(pointA, pointB, time);
        }


        //transform.position = new Vector3(Mathf.PingPong(Time.time * 40 * GameHandler.slowdownFactor, max - min) + min, transform.position.y, transform.position.z);

    }


    private void OnTriggerEnter(Collider other)
    {
        player.transform.parent = parent.transform;
    }

   
}
