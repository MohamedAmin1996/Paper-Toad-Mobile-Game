using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : PlayerStateBase
{
    public const string ID = "FALL";

    public override string Initialize(StateMachine stateMachine)
    {
        base.Initialize(stateMachine);
        return ID;
    }

    public override void Start()
    {
        Debug.Log("Entering FALL state");
        player.isOnGround = false;
    }

    public override void Update()
    {
        //Debug.Log("Updating FALL state");

        if (player.isOnGround && (player.input.x == 0f || player.input.y == 0f))
        {
            SwitchState(IdleState.ID);
            return;
        }

        if (player.isOnGround && (player.input.x > 0 || player.input.y > 0 || player.input.x < 0 || player.input.y < 0))
        {
            SwitchState(WalkState.ID);
            return;
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting FALL state");
        player.isOnGround = true;
    }

    public override void FixedUpdate()
    {

    }
}
