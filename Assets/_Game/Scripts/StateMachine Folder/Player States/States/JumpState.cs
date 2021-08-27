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
        AnimationSettings();
    }

    public override void Update()
    {
        //Debug.Log("Updating JUMP state");

        FlipSprite();      
    }

    public override void Exit()
    {
        Debug.Log("Exiting JUMP state");
    }

    public override void FixedUpdate()
    {
        player.rb.velocity = new Vector3(player.input.x * player.movementSpeed, player.rb.velocity.y, player.input.y * player.movementSpeed);

        if (player.rb.velocity.y < 0f)
        {
            SwitchState(FallState.ID);
            return;
        }
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
        player.spriteAnim.SetBool("isJumping", true);
        player.spriteAnim.SetBool("isFalling", false);

    }
}
