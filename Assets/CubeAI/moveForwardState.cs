using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardState : IState
{
    float speed = 50f;
    private CubeMovement cube;

    public void RunState(CubeMovement stateMachine)
    {
        stateMachine.Move(Vector3.forward, speed);
    }
    public IState CheckState(Vector3 cubePosition, Vector3 forwardDirection)
    {
        return this;
    }
    public void AddForce(Rigidbody rig, float speedToAdd)
    {
        rig.AddRelativeForce(Vector3.forward * speedToAdd);
    }
}