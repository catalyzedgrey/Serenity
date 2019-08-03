using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float smoothing = 5f;

    Vector3 offset;
    bool isFollowingPlayer = true;
    void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        
        if(!isFollowingPlayer)
            transform.position = Vector3.Lerp(transform.position, new Vector3(targetCamPos.x, this.transform.position.y, targetCamPos.z), smoothing * Time.deltaTime);
        else
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }

    public void SetTarget(Transform newTarget, bool isFollowingPlayer)
    {
        this.target = newTarget;
        this.isFollowingPlayer = isFollowingPlayer;
    }

}
