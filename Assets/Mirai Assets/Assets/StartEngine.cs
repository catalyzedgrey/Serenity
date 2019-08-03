using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEngine : MonoBehaviour
{
    bool shouldStart = false;
    Transform propeller1;
    // Start is called before the first frame update
    void Start()
    {
        propeller1 = transform.Find("propeller 1");
    }

    // Update is called once per frame
    void Update()
    {

        if (shouldStart)
        {
           transform.Rotate(Vector3.up, 360 * Time.deltaTime);
        }

    }
    
    public void SetStart()
    {
        shouldStart = true;
    }

}
