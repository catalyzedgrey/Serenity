using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWallCollision : MonoBehaviour
{

    Vector3 origPos;
    BackAndForth backAndForth;

    // Start is called before the first frame update
    void Start()
    {
        backAndForth = GetComponent<BackAndForth>();
        origPos = this.transform.position;
        Invoke("WaitForThreeSeconds", 5);
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void WaitForThreeSeconds()
    {
        backAndForth.SetEnabled(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag.Equals("Wall"))
        {
            this.enabled = false;
            backAndForth.SetEnabled(false);
            this.transform.position = origPos;
            this.enabled = true;
            Invoke("WaitForThreeSeconds", 5);
        }
    }
}
