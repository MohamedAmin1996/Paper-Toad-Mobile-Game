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
        AnimationSettings();
    }

    public override void Update()
    {
        //Debug.Log("Updating FALL state");

        if (player.isOnGround && (player.input.x > 0 || player.input.y > 0 || player.input.x < 0 || player.input.y < 0))
        {
            SwitchState(WalkState.ID);
            return;
        }
        if (player.isOnGround && (player.input.x == 0f || player.input.y == 0f))
        {
            SwitchState(IdleState.ID);
            return;
        }

        FlipSprite();
    }

    public override void Exit()
    {
        Debug.Log("Exiting FALL state");
        player.isOnGround = true;

        if (player.isOnGround && (player.input.x > 0 || player.input.y > 0 || player.input.x < 0 || player.input.y < 0))
        {
            player.spriteAnim.SetBool("isMoving", true);
            player.spriteAnim.SetBool("isFalling", false);
        }
        if (player.isOnGround && (player.input.x == 0f || player.input.y == 0f))
        {
            player.spriteAnim.SetBool("isMoving", false);
            player.spriteAnim.SetBool("isFalling", false);
        }
    }

    public override void FixedUpdate()
    {
        player.rb.velocity = new Vector3(player.input.x * player.movementSpeed, player.rb.velocity.y, player.input.y * player.movementSpeed);
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
        player.spriteAnim.SetBool("isFalling", true);
        player.spriteAnim.SetBool("isJumping", false);
    }
}
