using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightToggler : MonoBehaviour {
    private Light myLight;
    public float minIntensity;
    public float maxIntensity;
    [SerializeField] int delay;

    // Use this for initialization
    void Start () {
        myLight = GetComponent<Light>();
        if (myLight != null)
        {
            myLight.intensity = maxIntensity;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
