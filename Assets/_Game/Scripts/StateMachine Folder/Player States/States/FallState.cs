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
        AnimationSettings();

    }

    public override void Exit()
    {
        Debug.Log("Exiting FALL state");
        player.isOnGround = true;
    }

    public override void FixedUpdate()
    {
        //player.rb.AddForce(Vector2.right * player.input.x * player.movementSpeed);
        //player.rb.AddForce(Vector3.forward * player.input.y * player.movementSpeed);

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
