using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnRightState : IState
{
    [SerializeField] float speed = 40f;
    [SerializeField] float reduceBy = 1.1f;
    [SerializeField] Vector3 leftSide = new Vector3(-0.5f, 0, 0);
    [SerializeField] Vector3 rightSide = new Vector3(0.5f, 0, 0);
    [SerializeField] float wallDistance = 5f;
    public void RunState(cubeStateMachine stateMachine)
    {
        reduceVelocity(stateMachine.GetComponent<Rigidbody>(), reduceBy);
        AddRotation(stateMachine.GetComponent<Rigidbody>(), speed);
    }

    public void CheckState(cubeStateMachine stateMachine)
    {
        if (CheckForWalls(stateMachine, leftSide, wallDistance) || CheckForWalls(stateMachine, rightSide, wallDistance))
        {
            stateMachine.switchState(stateMachine.turnRightState);
        }
    }

    public void reduceVelocity(Rigidbody cubeRigidbody, float reduceVelocityBy)
    {
        cubeRigidbody.velocity /= reduceVelocityBy;
    }
    public void AddRotation(Rigidbody rig, float rotateSpeed)
    {
        rig.AddTorque(Vector3.up * rotateSpeed);
    }

    public bool CheckForWalls(cubeStateMachine stateMachine, Vector3 side, float distToCheck)
    {
        int layerMask = 1 << 7;
        RaycastHit hit;
        if (Physics.Raycast(stateMachine.transform.position + side, stateMachine.transform.TransformDirection(Vector3.forward), out hit, distToCheck, layerMask))
        {
            return true;
        }
        return false;
    }
    
}
