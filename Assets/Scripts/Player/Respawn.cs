using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public GameObject[] respawnPoints;



    public static bool isDead = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            switch (GameHandler.lvl)
            {
                case "1":
                    transform.position
                        = new Vector3 (respawnPoints[0].transform.position.x, transform.position.y, respawnPoints[0].transform.position.z);
                    break;

                case "2-1":
                    //transform.position = respawnPoints[1].transform.position;
                    transform.position
                        = new Vector3(respawnPoints[1].transform.position.x, transform.position.y, respawnPoints[1].transform.position.z);
                    break;
                case "2-2":
                    //transform.position = respawnPoints[2].transform.position;
                    transform.position
                        = new Vector3(respawnPoints[2].transform.position.x, transform.position.y, respawnPoints[2].transform.position.z);

                    break;
                case "3":
                    transform.position
                        = new Vector3(respawnPoints[3].transform.position.x, transform.position.y, respawnPoints[3].transform.position.z);

                    break;
                case "4-1":
                    transform.position = respawnPoints[4].transform.position;
                    
                    break;
                case "4-2":
                    transform.position = respawnPoints[5].transform.position;
                    
                    break;

                case "4-3":
                    transform.position = respawnPoints[6].transform.position;
                    break;
                default:
                    isDead = false;
                    break;
            }
            isDead = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            isDead = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            isDead = true;
        }
    }


}
