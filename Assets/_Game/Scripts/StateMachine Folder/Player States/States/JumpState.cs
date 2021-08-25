using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : PlayerStateBase
{
    public const string ID = "JUMP";

    public override string Initialize(StateMachine stateMachine)
    {
        base.Initialize(stateMachine);
        return ID;
    }

    public override void Start()
    {
       Debug.Log("Entering JUMP state");


        player.rb.velocity = new Vector2(player.rb.velocity.x, 0);
        player.rb.AddForce(Vector2.up * player.jumpHeight, ForceMode.Impulse);
        
    }

    public override void Update()
    {
        //Debug.Log("Updating JUMP state");
    }

    public override void Exit()
    {
        Debug.Log("Exiting JUMP state");
    }

    public override void FixedUpdate()
    {
        if (player.rb.velocity.y < .5f)
        {
            SwitchState(FallState.ID);
            return;
        }
    }
}
