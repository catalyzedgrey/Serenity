//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class AttachMotion : MonoBehaviour
//{
//    public GameObject toPoint;
//    public GameObject player;
//    public GameObject baseObject;

//    public char axis;

//    bool isWithinBounds = false;
//    bool enabled = false;

//    //public float baseObjectOffset, playerOffset;

//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (isWithinBounds && enabled)
//        {


//            switch (axis)
//            {
//                case 'x':
//                    this.transform.position = Vector3.MoveTowards(this.transform.position,
//                        new Vector3(toPoint.transform.position.x,
//                        this.transform.position.y,
//                        this.transform.position.z), Time.deltaTime * 3);

//                    player.transform.position = Vector3.MoveTowards(player.transform.position,
//                            new Vector3(toPoint.transform.position.x,
//                            player.transform.position.y,
//                            player.transform.position.z), Time.deltaTime * 3);
//                    break;

//                case 'y':

//                    this.transform.position = Vector3.MoveTowards(this.transform.position,
//                        new Vector3(this.transform.position.x,
//                        toPoint.transform.position.y,
//                        this.transform.position.z), Time.deltaTime * 3);

//                    player.transform.position = Vector3.MoveTowards(player.transform.position,
//                            new Vector3(toPoint.transform.position.x,
//                            player.transform.position.y,
//                            player.transform.position.z), Time.deltaTime * 3);
//                    break;

//                case 'z':


//                    this.transform.position = Vector3.MoveTowards(this.transform.position,
//                        new Vector3(this.transform.position.x,
//                        this.transform.position.y,
//                        toPoint.transform.position.z), Time.deltaTime * 3);

//                    player.transform.position = Vector3.MoveTowards(player.transform.position,
//                            new Vector3(player.transform.position.x,
//                            player.transform.position.y,
//                            toPoint.transform.position.z), Time.deltaTime * 3);
//                    break;

//            }


//        }
//        else if (baseObject.transform.position == toPoint.transform.position)
//        {
//            enabled = false;
//        }
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.name.Equals("Player"))
//        {
//            isWithinBounds = true;
//            enabled = true;
//        }
//    }
//}
