using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//if state = rotate, next state = move / idle


public class cubeStateMachine : cubeState
{
    float jumpTimer = 0f;
    //create new class - idle at interval
    [SerializeField] int countMoving = 0;
    [SerializeField] int countIdle = 0;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        checkForRotation();
        checkForJump();
        checkForIdle();
        checkForIdleOff();

        runState();
    }
    protected override void Start()
    {
        base.Start();
        countMoving = Random.Range(-250, 100);
        state = State.moveForward;
    }
    public void checkForRotation()
    {
        if (state == State.idle) { countIdle++; return; }
        if(state == State.Jump) { return; }

        countMoving++;
        int layerMask = 1 << 6;
        RaycastHit hit;
        //if wall in front of left of the ship - slow down and rotate 
        if (Physics.Raycast(transform.position+new Vector3(0.5f,0,0), transform.TransformDirection(Vector3.forward), out hit, 10f, layerMask))
        {
            reduceVelocity();
            selectRotateDirection();
        }
        //raycast from right of ship - detecting walls
        else if (Physics.Raycast(transform.position + new Vector3(-0.5f, 0, 0), transform.TransformDirection(Vector3.forward), out hit, 10f, layerMask))
        {
            reduceVelocity();
            selectRotateDirection();
        }
        //if no wall - ship should move forward
        else
        {
            state = State.moveForward;
            stateRotate = StateRotate.idle;
        }
    }
    public void checkForJump()
    {
        if (state == State.idle) { return; }
        jumpTimer += 1;
        if (jumpTimer > 60)
        {
            state = State.Jump;
            jumpTimer = Random.Range(-500,0);
        }
    }

    protected void checkForIdle()
    {
        if (countMoving >= 500)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
            countMoving = Random.Range(-250, 100);
            state = State.idle;
        }
    }
    protected void checkForIdleOff()
    {
        if (countIdle >= 180)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
            countIdle = Random.Range(-30, 30);
            state = State.moveForward;
        }
    }

    float reduceBy = 1.1f;
    public void reduceVelocity() //add a "slow down" function?
    {
        this.gameObject.GetComponent<Rigidbody>().velocity /= reduceBy;
    }
    protected virtual void selectRotateDirection()
    {
        switch (stateRotate) //if state = move - set rotation direction?
        {
            case StateRotate.RotatingLeft:
                state = State.TurnLeft;
                break;
            case StateRotate.RotatingRight:
                state = State.TurnRight;
                break;
            case StateRotate.idle:
                switch (Random.Range(1, 3))
                {
                    case 1:
                        stateRotate = StateRotate.RotatingLeft;
                        break;
                    case 2:
                        stateRotate = StateRotate.RotatingRight;
                        break;
                }
                break;
        }
    }
}
