using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpState : IState
{
    int jumpTimer = 0;
    float jumpForce = 400f;
    public void RunState(cubeStateMachine stateMachine)
    {
        stateMachine.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
    }

    public void CheckState(cubeStateMachine stateMachine)
    {
        jumpTimer += 1;
        if (checkTimerReached(jumpTimer,100))
        {
            stateMachine.switchState(stateMachine.jumpState);
            jumpTimer = setRandomWait(-500);
        }
    }

    public int setRandomWait(int min)
    {
        return Random.Range(min, 0);
    }
    public bool checkTimerReached(int currentTimer, int countToThis)
    {
        if (currentTimer >= countToThis)
        {
            return true;
        }
        return false;
    }
}
