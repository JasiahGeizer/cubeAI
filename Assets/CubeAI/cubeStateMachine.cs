using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStateMachine : MonoBehaviour
{
    IState currentState;
    public IState[] stat = new IState[] { new MoveForwardState(), new TurnRightState(), new TurnLeftState(), new JumpState(), new IdleState()};

    void Start()
    {

    }

    void FixedUpdate()
    {
        checkAllState();
    }

    public void switchState(IState state)
    {
        currentState = state;
    }
    public void checkAllState()
    {
        foreach (IState state in stat)
        {
            var newState = state.CheckState(this.gameObject.transform.position, this.gameObject.transform.TransformDirection(Vector3.forward));
            if (newState != null)
            {
                switchState(newState);
            }
        }
        currentState.RunState(this.GetComponent<CubeMovement>());
    }
}