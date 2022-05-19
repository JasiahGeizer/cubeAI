using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void RunState(cubeStateMachine stateMachine);
    void CheckState(cubeStateMachine stateMachine);
}