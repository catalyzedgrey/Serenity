using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public ElevatorControl elevatorControl;
    public PlayerMovement playerMovement;
    public GameHandler gameHandler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name.Equals("Player"))
        {
            switch (this.transform.name)
            {
                case "lvl0Handle":
                    GameHandler.lvl = "1";
                    elevatorControl.SetIsWithinBounds(true);
                    playerMovement.DisableMovement();
                    gameHandler.DisableSlowDown();
                    break;

                case "lvl1Handle":
                    GameHandler.lvl = "2-1";
                    elevatorControl.SetIsWithinBounds(true);
                    playerMovement.DisableMovement();
                    gameHandler.DisableSlowDown();
                    break;


                case "lvl2-1Handle":
                    GameHandler.lvl = "2-2";
                    break;

                case "lvl2-1-1Handle":
                    GameHandler.lvl = "2-2-1";
                    break;

                case "lvl2-2Handle":
                    GameHandler.lvl = "3";
                    elevatorControl.SetIsWithinBounds(true);
                    playerMovement.DisableMovement();
                    gameHandler.DisableSlowDown();
                    break;

                case "lvl3Handle":
                    GameHandler.lvl = "4";
                    elevatorControl.SetIsWithinBounds(true);
                    playerMovement.DisableMovement();
                    gameHandler.DisableSlowDown();
                    break;

                case "lvl4Handle":
                    GameHandler.lvl = "5";
                    elevatorControl.SetIsWithinBounds(true);
                    playerMovement.DisableMovement();
                    gameHandler.DisableSlowDown();
                    break;

                case "lvl5Handle":
                    GameHandler.lvl = "6";
                    elevatorControl.SetIsWithinBounds(true);
                    playerMovement.DisableMovement();
                    gameHandler.DisableSlowDown();
                    break;

                case "lvl9Handle":
                    GameHandler.lvl = "10";
                    elevatorControl.SetIsWithinBounds(true);
                    playerMovement.DisableMovement();
                    gameHandler.DisableSlowDown();
                    break;

            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.name.Equals("Player"))
        {
            GetComponent<SphereCollider>().enabled = false;
            //playerMovement.EnableMovement();
            //gameHandler.EnableSlowDown();
        }
    }
}
