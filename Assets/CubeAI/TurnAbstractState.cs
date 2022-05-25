using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class turnAbstractState : IState
{
    public virtual void RunState(CubeMovement stateMachine)
    { 

    }
    public virtual IState CheckState(Vector3 cubePosition, Vector3 forwardDirection)
    {
        return null;
    }

    public void reduceVelocity(CubeMovement stateMachine, float reduceVelocityBy)
    {
        stateMachine.Move(Vector3.back, reduceVelocityBy);
    }
    public void AddRotation(CubeMovement stateMachine, float rotateSpeed)
    {
        stateMachine.Rotate(Vector3.up, rotateSpeed);
    }

    public bool CheckForWalls(Vector3 cubePosition, Vector3 forwardDirection, Vector3 side, float distToCheck, int layerMask)
    {
        RaycastHit hit;
        //stateMachine.transform.TransformDirection(Vector3.forward)
        if (Physics.Raycast(cubePosition + side, forwardDirection, out hit, distToCheck, layerMask))
        {
            return true;
        }
        return false;
    }
}