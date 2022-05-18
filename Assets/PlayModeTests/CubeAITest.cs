using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CubeAITest
{
    [UnityTest]
    public IEnumerator moveForwardPlayModeTest()
    {
        GameObject cube = new GameObject();
        Rigidbody rig = cube.AddComponent<Rigidbody>();
        StateMachine stateMachine = cube.AddComponent<StateMachine>();
        moveForwardState moveForwardState = new moveForwardState();

        Assert.IsTrue(cube.GetComponent<Rigidbody>().velocity.magnitude <= 0);

        moveForwardState.AddForce(cube.GetComponent<Rigidbody>(), 50f);

        yield return new WaitForEndOfFrame();//awake
        yield return new WaitForEndOfFrame(); //start
        yield return new WaitForEndOfFrame(); 

        Assert.IsTrue(cube.GetComponent<Rigidbody>().velocity.magnitude > 0);
        Debug.Log(cube.GetComponent<Rigidbody>().velocity.magnitude);
    }

    [UnityTest]
    public IEnumerator turnRightPlayModeTestReduceVelocity()
    {
        GameObject cube = new GameObject();
        Rigidbody rig = cube.AddComponent<Rigidbody>();
        StateMachine stateMachine = cube.AddComponent<StateMachine>();
        turnRightState turnRightState = new turnRightState();

        cube.GetComponent<Rigidbody>().velocity = Vector3.forward;

        yield return new WaitForEndOfFrame();//awake
        yield return new WaitForEndOfFrame(); //start
        yield return new WaitForEndOfFrame(); 

        turnRightState.reduceVelocity(cube.GetComponent<Rigidbody>(), 1.1f);

        Assert.LessOrEqual(cube.GetComponent<Rigidbody>().velocity.magnitude, 1);
    }

    [UnityTest]
    public IEnumerator turnRightPlayModeTestRaycast()
    {
        //Create CubeAI
        GameObject cube = new GameObject();
        Rigidbody rig = cube.AddComponent<Rigidbody>();
        StateMachine stateMachine = cube.AddComponent<StateMachine>();
        turnRightState turnRightState = new turnRightState();

        //Create Wall
        GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wall.transform.position = new Vector3(0, 0f, 2);
        wall.transform.localScale = new Vector3(3, 1, 1);
        wall.AddComponent<BoxCollider>();
        
        //Wait for Awake & Start
        yield return new WaitForEndOfFrame();//awake
        yield return new WaitForEndOfFrame(); //start

        //Check if CubeAI can detect wall
        wall.layer = 7;
        Assert.IsTrue(turnRightState.CheckForWalls(cube.GetComponent<StateMachine>(), new Vector3(-0.5f, 0, 0), 5f));

        //Check if cubeAI isn't falsely detecting non-walls as walls
        wall.layer = 1;
        Assert.IsFalse(turnRightState.CheckForWalls(cube.GetComponent<StateMachine>(), new Vector3(-0.5f, 0, 0), 5f));
    }
    [UnityTest]
    public IEnumerator turnRightPlayModeTestAddRotation()
    {
        GameObject cube = new GameObject();
        Rigidbody rig = cube.AddComponent<Rigidbody>();
        StateMachine stateMachine = cube.AddComponent<StateMachine>();
        turnRightState turnRightState = new turnRightState();

        cube.GetComponent<Rigidbody>().velocity = Vector3.forward;

        yield return new WaitForEndOfFrame();//awake
        yield return new WaitForEndOfFrame(); //start

        turnRightState.AddRotation(cube.GetComponent<Rigidbody>(), 40f);

        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame(); 

        Assert.Greater(cube.GetComponent<Rigidbody>().angularVelocity.magnitude, 0);
        Debug.Log(cube.GetComponent<Rigidbody>().angularVelocity.magnitude);
    }
}
