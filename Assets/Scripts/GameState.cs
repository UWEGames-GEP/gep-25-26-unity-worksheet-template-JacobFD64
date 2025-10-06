using System;
using System.Collections.Generic;
using UnityEngine;

public class StateTransition
{
    public GameState FromState { get; private set; }
    public GameState ToState { get; private set; }
    public System.Func<bool> Condition { get; private set; }

    public StateTransition(GameState fromState, GameState toState, Func<bool> condition)
    {
        FromState = fromState;
        ToState = toState;
        Condition = condition;
    }
}
public abstract class GameState
{
    protected GameManager gameManager;
    private readonly List<StateTransition> transitions = new();
    public GameState(GameManager manager)
    {
        gameManager = manager;
    }
    
    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
    public void AddTransition(GameState targetState, System.Func<bool> condition)
    {
        transitions.Add(new StateTransition(this, targetState, condition));
    }
    public GameState CheckTransitions()
    {
        foreach (var t in transitions)
        {
            if(t.Condition.Invoke())
            {
                return t.ToState;
            }
        }
        return null;
    }
}
