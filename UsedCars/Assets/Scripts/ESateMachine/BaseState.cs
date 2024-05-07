
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
    /// Calls one time
    /// </summary>
    public abstract void EnterState();
    /// <summary>
    /// Cals when it exit the state
    /// </summary>
    public abstract void ExitState();
    /// <summary>
    /// Calls per frame
    /// </summary>
    public abstract void UpdateState();
    /// <summary>
    /// Get a next state
    /// </summary>
    /// <returns></returns>
    public abstract EState GetNextState();
    /// <summary>
    ///Abstract Trigger Enter
    /// </summary>
    /// <param name="other"></param>
    public abstract void OnTriggerEnter(Collider other);
    /// <summary>
    /// Abstract Ontrigger Stay
    /// </summary>
    /// <param name="other"></param>
    public abstract void OnTriggerStay(Collider other);
    /// <summary>
    /// Abstract OnTrigger Exit
    /// </summary>
    /// <param name="other"></param>
    public abstract void OnTriggerExit(Collider other);
}
 
