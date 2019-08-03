using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorControl : MonoBehaviour
{

    public GameObject leftElevator, rightElevator;
    public GameObject player;
    public PlayerMovement playerMovement;
    public GameHandler gameHandler;
    private bool enabled = false;
    private bool isInBounds = false;
    public GameObject[] elevatorStopPoints;
    public string tempLVL;
    public Fungus.Flowchart lvl6Flow, lvl9Flow;


    private float offsetElevY, maxElevHeight = 16f;
    float offsetPlayerY;

    float elevatorSpeed;
    // Use this for initialization
    void Start()
    {
        offsetElevY = 23f;
        offsetPlayerY = 23f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        elevatorSpeed = Time.deltaTime * 20;

        if (isInBounds)
        {

            switch (GameHandler.lvl)
            {
                case "1":
                    leftElevator.transform.position = Vector3.MoveTowards(leftElevator.transform.position,
                        new Vector3(leftElevator.transform.position.x, elevatorStopPoints[0].gameObject.transform.position.y, leftElevator.transform.position.z), elevatorSpeed);
                    player.transform.position = Vector3.MoveTowards(player.transform.position,
                        new Vector3(player.transform.position.x, elevatorStopPoints[0].gameObject.transform.position.y, player.transform.position.z), elevatorSpeed);

                    if (leftElevator.transform.position.y == elevatorStopPoints[0].gameObject.transform.position.y)
                    {
                        isInBounds = false;
                        playerMovement.EnableMovement();
                        gameHandler.EnableSlowDown();
                    }
                    break;

                case "2-1":
                    leftElevator.transform.position = Vector3.MoveTowards(leftElevator.transform.position,
                        new Vector3(leftElevator.transform.position.x, elevatorStopPoints[1].gameObject.transform.position.y, leftElevator.transform.position.z), elevatorSpeed);
                    rightElevator.transform.position = Vector3.MoveTowards(rightElevator.transform.position,
                        new Vector3(rightElevator.transform.position.x, elevatorStopPoints[1].gameObject.transform.position.y, rightElevator.transform.position.z), elevatorSpeed);
                    player.transform.position = Vector3.MoveTowards(player.transform.position,
                        new Vector3(player.transform.position.x, elevatorStopPoints[1].gameObject.transform.position.y, player.transform.position.z), elevatorSpeed);

                    if (leftElevator.transform.position.y == elevatorStopPoints[1].gameObject.transform.position.y
                        && rightElevator.transform.position.y == elevatorStopPoints[1].gameObject.transform.position.y
                        && player.transform.position.y == elevatorStopPoints[1].gameObject.transform.position.y)
                    {
                        isInBounds = false;
                        playerMovement.EnableMovement();
                        gameHandler.EnableSlowDown();
                    }
                    break;

                case "3":
                    leftElevator.transform.position = Vector3.MoveTowards(leftElevator.transform.position,
                        new Vector3(leftElevator.transform.position.x, elevatorStopPoints[2].gameObject.transform.position.y, leftElevator.transform.position.z), elevatorSpeed);
                    rightElevator.transform.position = Vector3.MoveTowards(rightElevator.transform.position,
                        new Vector3(rightElevator.transform.position.x, elevatorStopPoints[2].gameObject.transform.position.y, rightElevator.transform.position.z), elevatorSpeed);
                    player.transform.position = Vector3.MoveTowards(player.transform.position,
                        new Vector3(player.transform.position.x, elevatorStopPoints[2].gameObject.transform.position.y, player.transform.position.z), elevatorSpeed);

                    if (leftElevator.transform.position.y == elevatorStopPoints[2].gameObject.transform.position.y
                        && rightElevator.transform.position.y == elevatorStopPoints[2].gameObject.transform.position.y
                        && player.transform.position.y == elevatorStopPoints[2].gameObject.transform.position.y)
                    {
                        isInBounds = false;
                        playerMovement.EnableMovement();
                        gameHandler.EnableSlowDown();
                    }
                    break;

                case "4":
                    leftElevator.transform.position = Vector3.MoveTowards(leftElevator.transform.position,
                        new Vector3(leftElevator.transform.position.x, elevatorStopPoints[3].gameObject.transform.position.y, leftElevator.transform.position.z), elevatorSpeed);
                    rightElevator.transform.position = Vector3.MoveTowards(rightElevator.transform.position,
                        new Vector3(rightElevator.transform.position.x, elevatorStopPoints[3].gameObject.transform.position.y, rightElevator.transform.position.z), elevatorSpeed);
                    player.transform.position = Vector3.MoveTowards(player.transform.position,
                        new Vector3(player.transform.position.x, elevatorStopPoints[3].gameObject.transform.position.y, player.transform.position.z), elevatorSpeed);

                    if (leftElevator.transform.position.y == elevatorStopPoints[3].gameObject.transform.position.y
                        && rightElevator.transform.position.y == elevatorStopPoints[3].gameObject.transform.position.y
                        && player.transform.position.y == elevatorStopPoints[3].gameObject.transform.position.y)
                    {
                        isInBounds = false;
                        playerMovement.EnableMovement();
                        gameHandler.EnableSlowDown();
                    }
                        break;

                case "5":
                    leftElevator.transform.position = Vector3.MoveTowards(leftElevator.transform.position,
                        new Vector3(leftElevator.transform.position.x, elevatorStopPoints[4].gameObject.transform.position.y, leftElevator.transform.position.z), elevatorSpeed);
                    rightElevator.transform.position = Vector3.MoveTowards(rightElevator.transform.position,
                        new Vector3(rightElevator.transform.position.x, elevatorStopPoints[4].gameObject.transform.position.y, rightElevator.transform.position.z), elevatorSpeed);
                    player.transform.position = Vector3.MoveTowards(player.transform.position,
                        new Vector3(player.transform.position.x, elevatorStopPoints[4].gameObject.transform.position.y, player.transform.position.z), elevatorSpeed);

                    if (leftElevator.transform.position.y == elevatorStopPoints[4].gameObject.transform.position.y
                        && rightElevator.transform.position.y == elevatorStopPoints[4].gameObject.transform.position.y
                        && player.transform.position.y == elevatorStopPoints[4].gameObject.transform.position.y)
                    {
                        isInBounds = false;
                        playerMovement.EnableMovement();
                        gameHandler.EnableSlowDown();
                    }
                        break;

                case "6":
                    leftElevator.transform.position = Vector3.MoveTowards(leftElevator.transform.position,
                        new Vector3(leftElevator.transform.position.x, elevatorStopPoints[5].gameObject.transform.position.y, leftElevator.transform.position.z), elevatorSpeed);
                    rightElevator.transform.position = Vector3.MoveTowards(rightElevator.transform.position,
                        new Vector3(rightElevator.transform.position.x, elevatorStopPoints[5].gameObject.transform.position.y, rightElevator.transform.position.z), elevatorSpeed);
                    player.transform.position = Vector3.MoveTowards(player.transform.position,
                        new Vector3(player.transform.position.x, elevatorStopPoints[5].gameObject.transform.position.y, player.transform.position.z), elevatorSpeed);

                    if (leftElevator.transform.position.y == elevatorStopPoints[5].gameObject.transform.position.y
                        && rightElevator.transform.position.y == elevatorStopPoints[5].gameObject.transform.position.y
                        && player.transform.position.y == elevatorStopPoints[5].gameObject.transform.position.y)
                    {

                        lvl6Flow.SendFungusMessage("lvl6Fungus");
                        isInBounds = true;
                        //playerMovement.EnableMovement();
                        //gameHandler.EnableSlowDown();
                    }
                        break;

                case "9":
                    leftElevator.transform.position = Vector3.MoveTowards(leftElevator.transform.position,
                        new Vector3(leftElevator.transform.position.x, elevatorStopPoints[6].gameObject.transform.position.y, leftElevator.transform.position.z), elevatorSpeed);
                    rightElevator.transform.position = Vector3.MoveTowards(rightElevator.transform.position,
                        new Vector3(rightElevator.transform.position.x, elevatorStopPoints[6].gameObject.transform.position.y, rightElevator.transform.position.z), elevatorSpeed);
                    player.transform.position = Vector3.MoveTowards(player.transform.position,
                        new Vector3(player.transform.position.x, elevatorStopPoints[6].gameObject.transform.position.y, player.transform.position.z), elevatorSpeed);

                    if (leftElevator.transform.position.y == elevatorStopPoints[6].gameObject.transform.position.y
                        && rightElevator.transform.position.y == elevatorStopPoints[6].gameObject.transform.position.y
                        && player.transform.position.y == elevatorStopPoints[6].gameObject.transform.position.y)
                    {
                        isInBounds = false;
                        playerMovement.EnableMovement();
                        gameHandler.EnableSlowDown();
                    }
                    break;

                case "10":
                    leftElevator.transform.position = Vector3.MoveTowards(leftElevator.transform.position,
                        new Vector3(leftElevator.transform.position.x, elevatorStopPoints[7].gameObject.transform.position.y, leftElevator.transform.position.z), elevatorSpeed);
                    rightElevator.transform.position = Vector3.MoveTowards(rightElevator.transform.position,
                        new Vector3(rightElevator.transform.position.x, elevatorStopPoints[7].gameObject.transform.position.y, rightElevator.transform.position.z), elevatorSpeed);
                    player.transform.position = Vector3.MoveTowards(player.transform.position,
                        new Vector3(player.transform.position.x, elevatorStopPoints[7].gameObject.transform.position.y, player.transform.position.z), elevatorSpeed);

                    if (leftElevator.transform.position.y == elevatorStopPoints[7].gameObject.transform.position.y
                        && rightElevator.transform.position.y == elevatorStopPoints[7].gameObject.transform.position.y
                        && player.transform.position.y == elevatorStopPoints[7].gameObject.transform.position.y)
                    {
                        lvl9Flow.SendFungusMessage("lvl9Fungus");
                        isInBounds = false;

                    }
                    break;

                default:
                    break;


            }
        }



    }


    public void SkipLevels()
    {
        GameHandler.lvl = "9";
    }
    public void SetIsWithinBounds(bool isWithinBounds)
    {
        isInBounds = isWithinBounds;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name.Equals("Player"))
        {
            isInBounds = true;
            //player.gameObject.SendMessage();

        }

    }
}
