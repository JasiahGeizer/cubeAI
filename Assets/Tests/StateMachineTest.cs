using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;

public class StateMachineTest 
{
    private GameObject gameobj;
    public moveForwardState moveForwardState = new moveForwardState();
    public jumpState jumpState = new jumpState();
    public cubeStateMachine stateMachine = new cubeStateMachine();

    [Test]
    public void idleStateTest()
    {
        idleState state = new idleState();

        Assert.IsTrue(state.setRandomWait(0) == 0);
        var wait = state.setRandomWait(-350);
        Assert.IsTrue(wait <= 0 && wait >= -350);

        Assert.IsTrue(state.checkTimerReached(1,1));
        Assert.IsFalse(state.checkTimerReached(0, 10));
    }
    [Test]
    public void JumpStateTest()
    {
        jumpState state = new jumpState();

        Assert.IsTrue(state.setRandomWait(0) == 0);
        var wait = state.setRandomWait(-350);
        Assert.IsTrue(wait <= 0 && wait >= -350);

        Assert.IsTrue(state.checkTimerReached(1, 1));
        Assert.IsFalse(state.checkTimerReached(0, 10));
    }
}
