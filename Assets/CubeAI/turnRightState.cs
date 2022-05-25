using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRightState : turnAbstractState
{
    [SerializeField] float speed = 40f;
    [SerializeField] float reduceBy = 100f;
    [SerializeField] Vector3 leftSide = new Vector3(-0.5f, 0, 0);
    [SerializeField] Vector3 rightSide = new Vector3(0.5f, 0, 0);
    [SerializeField] float wallDistance = 5f;

    public override void RunState(CubeMovement stateMachine)
    {
        base.RunState(stateMachine);
        reduceVelocity(stateMachine, reduceBy);
        AddRotation(stateMachine, speed);
    }

    public override IState CheckState(Vector3 cubePosition, Vector3 forwardDirection)
    {
        int layerMask = 1 << LayerMask.NameToLayer("Wall");
        if (CheckForWalls(cubePosition, forwardDirection, leftSide, wallDistance, layerMask) || CheckForWalls(cubePosition, forwardDirection, rightSide, wallDistance, layerMask))
        {
            return this;
        }
        return null;
    }
}