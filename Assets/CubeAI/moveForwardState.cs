using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForwardState : IState
{
    float speed = 50f;
    public void RunState(cubeStateMachine stateMachine)
    {
        AddForce(stateMachine.GetComponent<Rigidbody>(), speed);
    }
    public void CheckState(cubeStateMachine stateMachine)
    {
        stateMachine.switchState(stateMachine.moveForwardState);
    }
    public void AddForce(Rigidbody rig, float speedToAdd)
    {
        rig.AddRelativeForce(Vector3.forward * speedToAdd);
    }
}
