using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpEyes : MonoBehaviour
{
    public Transform EyePos;
    public Transform Body;
    public float smoothTime = 0.5f;
    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, EyePos.position, ref velocity, smoothTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Body.rotation, smoothTime);
    }
}
