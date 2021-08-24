using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateBase
{
    protected StateMachine stateMachine;
    public virtual string Initialize(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        return "NULL";
    }
    public abstract void Start(); 
    public abstract void Update();
    public abstract void FixedUpdate();
    public abstract void Exit();
    public void SwitchState(string stateID)
    {
        stateMachine.SwitchState(stateID);
    }
}
