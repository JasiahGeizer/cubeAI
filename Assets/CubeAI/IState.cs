using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void RunState(CubeMovement stateMachine);
    IState CheckState(Vector3 cubePosition, Vector3 forwardDirection);
}