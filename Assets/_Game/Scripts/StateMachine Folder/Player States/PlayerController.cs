using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : StateMachine
{
    public MasterControls masterControls;
    public Animator playerAnim;
    public Animator spriteAnim;
    public SpriteRenderer sr;
    public Rigidbody rb;
    public Vector2 input;

    public float movementSpeed = 5;
    public float jumpHeight = 5;
    public bool isOnGround = true;

    protected override void Awake()
    {
        base.Awake();

        masterControls = new MasterControls();
        masterControls.Player.Enable();

        AddState(new IdleState());
        AddState(new WalkState());
        AddState(new JumpState());
        AddState(new FallState());
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        input = masterControls.Player.Movement.ReadValue<Vector2>().normalized;
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isOnGround = true;
        }
    }
}
