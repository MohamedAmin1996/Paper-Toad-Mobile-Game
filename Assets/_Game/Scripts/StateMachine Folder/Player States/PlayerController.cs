using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : StateMachine
{
    public MasterControls masterControls;
    public Vector2 input;
    public float speed = 5;
    protected override void Awake()
    {
        base.Awake();

        masterControls = new MasterControls();
        masterControls.Player.Enable();

        AddState(new IdleState());
        AddState(new WalkState());
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
