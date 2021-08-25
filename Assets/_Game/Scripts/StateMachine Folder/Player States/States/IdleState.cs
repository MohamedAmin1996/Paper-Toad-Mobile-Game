using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
        player.rb.velocity = new Vector2(0, player.rb.velocity.y);
    }

    public override void Update()
    {
        //Debug.Log("Updating IDLE state");

        if (player.input.x != 0 || player.input.y != 0)
        {
            SwitchState(WalkState.ID);
            return;
        }

        if (player.masterControls.Player.Jump.ReadValue<float>() == 1 && player.isOnGround)
        {
            SwitchState(JumpState.ID);
            return;
        }

        player.spriteAnim.SetBool("isMoving", false); 
    }

    public override void Exit()
    {
        Debug.Log("Exiting IDLE state");
    }

    public override void FixedUpdate()
    {
        if (!player.isOnGround)
        {
            SwitchState(FallState.ID);
            return;
        }
    }
}
