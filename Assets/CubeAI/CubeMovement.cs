using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : CubeStateMachine
{
    public void Move(Vector3 direction, float speed)
    {
        this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(direction * speed);
    }
    public void Rotate(Vector3 direction, float speed)
    {
        this.gameObject.GetComponent<Rigidbody>().AddTorque(direction * speed);
    }
    public void changeColor()
    {

    }
}
