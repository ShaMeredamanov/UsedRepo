using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class BaseState<EState> where EState : Enum
{
    /// <summary>
    /// There is constructor what makes Generic type equal this type 
    /// </summary>
    /// <param name="key"></param>
    public BaseState(EState key){
        StateKey = key;
    }
    /// <summary>
    /// There is Generic type EState what we need to meka equal to base constructor
    /// </summary>
    public EState StateKey { get; private set; }
    /// <summary>
    /// calls one time
    /// </summary>
    public abstract void EnterState();
    /// <summary>
    /// cals when it exit the state
    /// </summary>
    public abstract void ExitState();
    /// <summary>
    /// calls per frame
    /// </summary>
    public abstract void UpdateState();
    /// <summary>
    /// get a next state
    /// </summary>
    /// <returns></returns>
    public abstract EState GetNextState();

}