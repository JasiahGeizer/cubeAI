using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnRightState : IState
{
    float speed = 40f;
    public void RunState(StateMachine stateMachine)
    {
        stateMachine.GetComponent<Rigidbody>().AddTorque(Vector3.down * speed);
    }

    public void CheckState(StateMachine stateMachine)
    {
        if (CheckForWalls(stateMachine))
        {
            stateMachine.switchState(stateMachine.turnRightState);
            reduceVelocity(stateMachine);
        }
    }

    [SerializeField] float reduceBy = 1.1f;
    public void reduceVelocity(StateMachine stateMachine)
    {
        stateMachine.GetComponent<Rigidbody>().velocity /= reduceBy;
    }

    [SerializeField] float wallDistance = 5f;
    [SerializeField] Vector3 leftSide = new Vector3(-0.5f, 0, 0);
    private bool CheckForWalls(StateMachine stateMachine)
    {
        int layerMask = 1 << 6;
        RaycastHit hit;
        if (Physics.Raycast(stateMachine.transform.position + leftSide, stateMachine.transform.TransformDirection(Vector3.forward), out hit, wallDistance, layerMask))
        {
            return true;
        }
        return false;
    }
}
