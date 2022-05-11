using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class cubeState : MonoBehaviour
{
    public enum State
    {
        idle, moveForward, TurnLeft, TurnRight, Jump
    }

    public enum StateRotate
    {
        RotatingLeft, RotatingRight, idle
    }

    public State state = State.idle;
    public StateRotate stateRotate = StateRotate.idle;

    protected virtual void idle()
    {
    }
    protected virtual void moveForward()
    {
        this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 50);
    }
    protected virtual void TurnLeft()
    {
        this.gameObject.GetComponent<Rigidbody>().AddTorque(-Vector3.up * 50);
    }
    protected virtual void TurnRight()
    {
        this.gameObject.GetComponent<Rigidbody>().AddTorque(Vector3.up * 50);
    }
    protected virtual void Jump()
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 400);
        state = State.moveForward;
    }
    protected virtual void runState()
    {
        switch (state)
        {
            case State.idle:
                idle();
                break;
            case State.moveForward:
                moveForward();
                break;
            case State.TurnLeft:
                TurnLeft();
                break;
            case State.TurnRight:
                TurnRight();
                break;
            case State.Jump:
                Jump();
                break;
        }
    }
    protected virtual void FixedUpdate()
    { 
    }
    protected virtual void Start()
    {
    }
}
