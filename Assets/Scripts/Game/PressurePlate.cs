using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour, ITimeScalable {

    bool isWithinBounds = false;
    public GameObject cube;
    public Material redColor;
    public Material greenColor;
    public Animator animator;

    // Use this for initialization
    void Start () {
        cube.GetComponent<MeshRenderer>().material = redColor;
        animator.speed = 3;
        GameHandler.interfaceScripts.Add(this);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.name.Equals("Player"))
        {
            cube.transform.position = new Vector3(cube.transform.position.x, cube.transform.position.y - 0.25f, cube.transform.position.z) ;
            animator.SetBool("IsWithinBounds", true);
            isWithinBounds = true;
            cube.GetComponent<MeshRenderer>().material = greenColor;
        }

    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            cube.transform.position = new Vector3(cube.transform.position.x, cube.transform.position.y + 0.25f, cube.transform.position.z);
            animator.SetBool("IsWithinBounds", false);
            isWithinBounds = false;
            cube.GetComponent<MeshRenderer>().material = redColor;
        }
    }

    public bool GetIsWithinBounds()
    {
        return isWithinBounds;
    }

    public void SlowDown()
    {
        animator.speed = GameHandler.slowdownFactor;
    }

    public void ResetSpeed()
    {
        animator.speed = 3f;
    }
}
