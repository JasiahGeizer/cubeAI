using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    IState currentState;
    public jumpState jumpState = new jumpState();
    public moveForwardState moveForwardState = new moveForwardState();
    public turnLeftState turnLeftState = new turnLeftState();
    public turnRightState turnRightState = new turnRightState();
    public idleState idleState = new idleState();

    void Start()
    {
        currentState = idleState;
    }

    void FixedUpdate()
    {
        moveForwardState.CheckState(this);
        turnRightState.CheckState(this);
        turnLeftState.CheckState(this);
        jumpState.CheckState(this);
        idleState.CheckState(this);
        currentState.RunState(this);
    }

    public void switchState(IState state)
    {
        currentState = state;
    }
}
