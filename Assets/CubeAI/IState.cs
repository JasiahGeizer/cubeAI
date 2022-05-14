using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void RunState(StateMachine stateMachine);
    void CheckState(StateMachine stateMachine);
}