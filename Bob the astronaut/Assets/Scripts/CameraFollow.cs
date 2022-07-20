using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float DampTime = 0.5f;
    Vector3 targetPos;
    Vector3 velocity = Vector3.zero;
    void Update()
    {
        targetPos = new Vector3(target.position.x, target.position.y, -10);
        transform.position = Vector3.SmoothDamp(gameObject.transform.position, targetPos, ref velocity, DampTime);
    }
}