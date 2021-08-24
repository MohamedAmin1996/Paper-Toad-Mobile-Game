using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : PlayerStateBase
{
    public const string ID = "WALK";
    public override string Initialize(StateMachine stateMachine)
    {
        base.Initialize(stateMachine);
        return ID;
    }

    public override void Start()
    {
        Debug.Log("Entering WALK state");
    }

    public override void Update()
    {
        Debug.Log("Updating WALK state");

        player.input = player.masterControls.Player.Movement.ReadValue<Vector2>().normalized;

        if ((player.input.x == 0f || player.input.y == 0f))
        {
            SwitchState(IdleState.ID);
            return;
        }

        player.transform.position += new Vector3(player.input.x, 0, player.input.y) * Time.deltaTime * player.speed;
    }

    public override void Exit()
    {
        Debug.Log("Exiting WALK state");
    }

    public override void FixedUpdate()
    {
        
    }
}
