using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private Dictionary<string, StateBase> states;
    public string stateID = "";
    private string startState = "";
    protected StateBase currentState { get { return states[stateID]; } }

    protected virtual void Awake()
    {
        states = new Dictionary<string, StateBase>();
    }

    protected virtual void Start()
    {
        if (states.ContainsKey(startState))
        {
            EnterState(startState);
        }
    }

    protected virtual void Update()
    {
        currentState.Update();
    }

    protected virtual void FixedUpdate()
    {
        currentState.FixedUpdate();
    }

    public void AddState(StateBase state)
    {
        states.Add(state.Initialize(this), state);
    }

    public virtual void SwitchState(string stateID)
    {
        ExitState();
        EnterState(stateID);
    }

    protected void EnterState(string stateID)
    {
        this.stateID = stateID;
        currentState.Start();
    }

    private void ExitState()
    {
        currentState.Exit();
    }
}
