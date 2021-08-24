using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerStateBase
{
    public const string ID = "IDLE";



    public override string Initialize(StateMachine stateMachine)
    {
        base.Initialize(stateMachine);
        return ID;
    }

    public override void Start()
    {
        Debug.Log("Entering IDLE state");
    }

    public override void Update()
    {
        Debug.Log("Updating IDLE state");

        player.input = player.masterControls.Player.Movement.ReadValue<Vector2>().normalized;

        if (player.input.x > 0 || player.input.y > 0)
        {
            SwitchState(WalkState.ID);
            return;
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting IDLE state");
    }

    public override void FixedUpdate()
    {
       
    }
}
