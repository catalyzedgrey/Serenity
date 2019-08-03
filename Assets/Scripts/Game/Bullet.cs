using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, ITimeScalable
{
    [SerializeField] Animator animator;
    // Use this for initialization
    void Start()
    {
        GameHandler.interfaceScripts.Add(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ITimeScalable.SlowDown()
    {
        animator.speed = GameHandler.slowdownFactor;
    }

    void ITimeScalable.ResetSpeed()
    {
        animator.speed = 1;
    }
}
