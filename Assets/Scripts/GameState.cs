using System;
using System.Collections.Generic;
using UnityEngine;

public class StateTransition
{
    public GameState FromState { get; private set; }
    public GameState ToState { get; private set; }
    public Func<bool> Condition { get; private set; }

    public StateTransition(GameState fromState, GameState toState, Func<bool> condition)
    {
        FromState = fromState;
        ToState = toState;
        Condition = condition;
    }
}
public abstract class GameState
{
    private readonly List<StateTransition> transitions = new();
    
    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
    public void AddTransition(GameState targetState, Func<bool> condition)
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
