using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForwardState : IState
{
    float speed = 50f;
    public void RunState(StateMachine stateMachine)
    {
        stateMachine.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed);
    }
    public void CheckState(StateMachine stateMachine)
    {
        stateMachine.switchState(stateMachine.moveForwardState);
    }
}
