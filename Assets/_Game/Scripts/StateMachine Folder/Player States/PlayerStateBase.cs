using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStateBase : StateBase
{
    public PlayerController player;

    public override string Initialize(StateMachine statemachine)
    {
        player = (PlayerController)statemachine;
        base.Initialize(statemachine);
        return "NULL";
    }
    public override abstract void Start();
    public override abstract void Update();
    public override abstract void FixedUpdate();
    public override abstract void Exit();
}
