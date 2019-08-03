using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownAnimator : MonoBehaviour, ITimeScalable {

    [SerializeField] Animator animator;
    public float slowDownSpeed;
    float defaultSlowDownSpeed;
	// Use this for initialization
	void Start () {
        if (animator == null)
            animator = GetComponent<Animator>();
        GameHandler.interfaceScripts.Add(this);

        defaultSlowDownSpeed = 0.15f;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ITimeScalable.SlowDown()
    {
        if(animator != null)
        {
            if (slowDownSpeed == 0)
                animator.speed = defaultSlowDownSpeed;
            else
                animator.speed = slowDownSpeed;
        }
            
    }

    void ITimeScalable.ResetSpeed()
    {
        if (animator != null)
            animator.speed = 1f;
    }
}
