using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    public int countIdle = 0;
    public int startIdle = 500;
    const int endIdle = 700;
    const int maxRange = 0;

    public void RunState(CubeMovement stateMachine)
    {
        /*stateMachine.GetComponent<Renderer>().material.color = Color.blue;
        if (checkTimerReached(countIdle, endIdle))
        {
            countIdle = setRandomWait(-350);
            stateMachine.GetComponent<Renderer>().material.color = Color.red;
        }*/
    }

    public IState CheckState(Vector3 cubePosition, Vector3 forwardDirection)
    {
        countIdle += 1;
        if (checkTimerReached(countIdle, startIdle))
        {
            if (countIdle > endIdle) { countIdle = 0; }
            //stateMachine.switchState(this);
            return this;
        }
        return null;
    }

    public int setRandomWait(int min)
    {
        return Random.Range(min, maxRange);
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