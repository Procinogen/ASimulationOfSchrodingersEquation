﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecStates : MonoBehaviour
{
    #region State Stuff
    //States
    public enum States {
        IDLE,
        TALKING,
        MOVING
    }

    //Whatever state he's currently in
    public States currentState;

    #endregion State Stuff

    #region State Functions
    //Functions for setting state \/
    public void setToIdle()
    {
        currentState = States.IDLE;
        return;
    }

    public void setToTalking()
    {
        currentState = States.TALKING;
        return;
    }

    public void setToMoving()
    {
        currentState = States.MOVING;
        return;
    }
    #endregion State Functions

    public Vector3 oldPosition;

    void Start()
    {
        oldPosition = transform.position;
        setToIdle();
    }
    //Functions for setting state /\

    public float amplitude = 0.0015f; //Changes the amplitude of the sine function that controls his idle movement
    public float phaseShift = 0.05f; //Changes the phase shift of the sine function that controls his idle movement

    // Update is called once per frame
    void Update()
    {
        //Check his state
        switch (currentState)
        {
            case States.IDLE:
                Vector3 targetPositionRaw = new Vector3(0, Mathf.Sin(Time.frameCount * phaseShift) * Mathf.Rad2Deg, 0); //Changes his target position to be his original position offset by whatever amount the sine function says so
                transform.position = oldPosition + (targetPositionRaw * amplitude); //transform his position
                break;
            case States.MOVING:
                oldPosition = transform.position;
                transform.LookAt(GameObject.FindGameObjectsWithTag("MainCamera")[0].transform.position);
                break;
            default:
                break;

        }
    }
}
