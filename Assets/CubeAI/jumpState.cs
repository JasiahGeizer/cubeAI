using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IState
{
    int jumpTimer = 0;
    float jumpForce = 400f;
    const int maxWait = 0;
    int jumpMin = -500;
    int countTo = 100;

    public void RunState(CubeMovement stateMachine)
    {
        stateMachine.Move(Vector3.up, jumpForce);
    }

    public IState CheckState(Vector3 cubePosition, Vector3 forwardDirection)
    {
        jumpTimer += 1;
        if (checkTimerReached(jumpTimer, countTo))
        {
            jumpTimer = setRandomWait(jumpMin);
            return this;
        }
        return null;
    }

    public int setRandomWait(int min)
    {
        return Random.Range(min, maxWait);
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