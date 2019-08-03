using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSimulation : MonoBehaviour, ITimeScalable
{

    public float speed = 1f;
    public ParticleSystem particles;
    ParticleSystem.MainModule main;

    // Use this for initialization
    void Start()
    {
        main = particles.main;
        GameHandler.interfaceScripts.Add(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SlowDown()
    {
        if (this != null)
            main.simulationSpeed = 0.2f;
    }
    public void ResetSpeed()
    {
        if (this != null)
            main.simulationSpeed = 1f;
    }
    //public void SlowDownRain()
    //{
    //    main.simulationSpeed = 0.2f;
    //}

    //public void ResetRainSpeed()
    //{
    //    main.simulationSpeed = 1f;
    //}
}
