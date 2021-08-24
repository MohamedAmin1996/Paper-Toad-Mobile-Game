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
        FlipSprite();
        AnimationSettings();
    }

    public override void Exit()
    {
        Debug.Log("Exiting WALK state");
    }

    public override void FixedUpdate()
    {
        
    }

    void FlipSprite()
    {
        if (player.input.x > 0 && !player.sr.flipX)
        {
            player.sr.flipX = true;
            player.playerAnim.SetTrigger("Flip");
            player.playerAnim.SetFloat("Direction", 1);
        }
        else if (player.input.x < 0 && player.sr.flipX)
        {
            player.sr.flipX = false;
            player.playerAnim.SetTrigger("Flip");
            player.playerAnim.SetFloat("Direction", -1);
        }
    }

    void AnimationSettings()
    {
        if (player.input.y > 0 && player.input.x == 0) // North
        {
            player.spriteAnim.SetFloat("MoveY", 1);
            player.spriteAnim.SetBool("isMoving", true);
        }
        else if (player.input.y > 0 && player.input.x > 0) // North East
        {
            player.spriteAnim.SetFloat("MoveY", 1);
            player.spriteAnim.SetBool("isMoving", true);
        }
        else if (player.input.y == 0 && player.input.x > 0) // East
        {
            player.spriteAnim.SetFloat("MoveY", -1);
            player.spriteAnim.SetBool("isMoving", true);
        }
        else if (player.input.y < 0 && player.input.x > 0) // South East
        {
            player.spriteAnim.SetFloat("MoveY", -1);
            player.spriteAnim.SetBool("isMoving", true);
        }
        else if (player.input.y < 0 && player.input.x == 0) // South
        {
            player.spriteAnim.SetFloat("MoveY", -1);
            player.spriteAnim.SetBool("isMoving", true);
        }
        else if (player.input.y < 0 && player.input.x < 0) // South West
        {
            player.spriteAnim.SetFloat("MoveY", -1);
            player.spriteAnim.SetBool("isMoving", true);
        }
        else if (player.input.y == 0 && player.input.x < 0) // West
        {
            player.spriteAnim.SetFloat("MoveY", -1);
            player.spriteAnim.SetBool("isMoving", true);
        }
        else if (player.input.y > 0 && player.input.x < 0) // North West
        {
            player.spriteAnim.SetFloat("MoveY", 1);
            player.spriteAnim.SetBool("isMoving", true);
        }
        else
        {
            player.spriteAnim.SetBool("isMoving", false);
        }
    }
}
