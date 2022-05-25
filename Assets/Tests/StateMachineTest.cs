using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;

public class StateMachineTest 
{
    private GameObject gameobj;
    public MoveForwardState moveForwardState = new MoveForwardState();
    public JumpState jumpState = new JumpState();
    public CubeMovement stateMachine = new CubeMovement();

    [Test]
    public void idleStateTest()
    {
        IdleState state = new IdleState();

        Assert.IsTrue(state.setRandomWait(0) == 0);
        var wait = state.setRandomWait(-350);
        Assert.IsTrue(wait <= 0 && wait >= -350);

        Assert.IsTrue(state.checkTimerReached(1,1));
        Assert.IsFalse(state.checkTimerReached(0, 10));
    }
    [Test]
    public void JumpStateTest()
    {
        JumpState state = new JumpState();

        Assert.IsTrue(state.setRandomWait(0) == 0);
        var wait = state.setRandomWait(-350);
        Assert.IsTrue(wait <= 0 && wait >= -350);

        Assert.IsTrue(state.checkTimerReached(1, 1));
        Assert.IsFalse(state.checkTimerReached(0, 10));
    }
}