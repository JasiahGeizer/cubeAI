using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleState : IState
{
    int countIdle = 0;
    int startIdle = 500;
    int endIdle = 700;
    public void RunState(StateMachine stateMachine)
    {
        stateMachine.GetComponent<Renderer>().material.color = Color.blue;
        if (checkTimerReached(countIdle, endIdle))
        {
            countIdle = setRandomWait(-350);
            stateMachine.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    public void CheckState(StateMachine stateMachine)
    {
        countIdle += 1;
        if (checkTimerReached(countIdle, startIdle))
        {
            stateMachine.switchState(stateMachine.idleState);
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
