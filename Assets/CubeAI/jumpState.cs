using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpState : IState
{
    int jumpTimer = 0;
    float jumpForce = 400f;
    public void RunState(StateMachine stateMachine)
    {
        stateMachine.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
    }

    public void CheckState(StateMachine stateMachine)
    {
        jumpTimer += 1;
        if (jumpTimer > 100)
        {
            stateMachine.switchState(stateMachine.jumpState);
            jumpTimer = setRandomWait(-500);
        }
    }

    public int setRandomWait(int min)
    {
        return Random.Range(min, 0);
    }
}
