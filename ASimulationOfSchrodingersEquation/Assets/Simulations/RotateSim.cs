using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSim : MonoBehaviour
{
    public float speed = 1.0f;
    public GameObject cam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            //Debug.Log(true);
            RotateObject();
        }
    }

    void RotateObject()
    {
        transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0) * Time.deltaTime * speed);
    }

}
