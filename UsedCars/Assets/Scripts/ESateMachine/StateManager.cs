using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract class StateManager<EState> : MonoBehaviour where EState : Enum
{
   public Dictionary<EState, BaseState<EState>> States = new Dictionary<EState, BaseState<EState>>();

   public  BaseState<EState> CurrentState;

    private bool isTarnsitioningState = false;
    private void Start(){

        CurrentState.EnterState();
    }
    private void Update(){
        EState nextStateKey = CurrentState.GetNextState();
        if (!isTarnsitioningState && nextStateKey.Equals(CurrentState.StateKey))
        {
            CurrentState.UpdateState();
        }
        else if(!isTarnsitioningState)
        {
            TransitionToState(nextStateKey);
        }
        Debug.Log("i am state manager");
    }
    public void TransitionToState(EState stateKey)
    {
        Debug.Log("transition to state");
        isTarnsitioningState = true;
        CurrentState.ExitState();
        CurrentState = States[stateKey];
        CurrentState.EnterState();
        isTarnsitioningState = false;
    }
  
}
