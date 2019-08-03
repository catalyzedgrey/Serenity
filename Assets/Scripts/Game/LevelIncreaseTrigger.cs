using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelIncreaseTrigger : MonoBehaviour
{
    public string lvl;
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
        
        if(other.tag.Equals("Player"))
        {

        }
    }
}
