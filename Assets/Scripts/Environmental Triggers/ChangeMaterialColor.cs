using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialColor : MonoBehaviour
{
    private Material oldMat;
    public Material newMat;
    // Start is called before the first frame update
    void Start()
    {
        oldMat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerColorChange()
    {
        Renderer r = GetComponent<Renderer>();
        if (r.material == oldMat)
        {
            r.material = newMat;
        }
    }
}
