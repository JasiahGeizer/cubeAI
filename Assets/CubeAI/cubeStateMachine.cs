using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeStateMachine : cubeState
{
    [SerializeField] float jumpTimer = 0f;
    [SerializeField] float wallDistance = 10f;
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
        //if wall is in front of left of the cube - slow down and rotate 
        if (Physics.Raycast(transform.position + new Vector3(0.5f,0,0), transform.TransformDirection(Vector3.forward), out hit, wallDistance, layerMask))
        {
            reduceVelocity();
            selectRotateDirection();
        }
        //if wall is in front of left of the cube - slow down and rotate
        else if (Physics.Raycast(transform.position + new Vector3(-0.5f, 0, 0), transform.TransformDirection(Vector3.forward), out hit, wallDistance, layerMask))
        {
            reduceVelocity();
            selectRotateDirection();
        }
        //if there's no wall in front of cube - move forward
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

    protected void checkForIdle() //After set time of movement, set cube to idle.
    {
        if (countMoving >= 500)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
            countMoving = Random.Range(-250, 100);
            state = State.idle;
        }
    }
    protected void checkForIdleOff() //After Idle times out, set cube to move.
    {
        if (countIdle >= 180)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
            countIdle = Random.Range(-30, 30);
            state = State.moveForward;
        }
    }

    [SerializeField] float reduceBy = 1.1f;
    public void reduceVelocity() 
    {
        this.gameObject.GetComponent<Rigidbody>().velocity /= reduceBy;
    }
    protected virtual void selectRotateDirection()
    {
        switch (stateRotate) 
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
