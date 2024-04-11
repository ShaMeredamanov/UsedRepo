using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EskaltorInteractionWaitCarState : EskalatorBaseIteractionState
{
  
    public EskaltorInteractionWaitCarState(EskalatorContextState context, EskalatorInteractionStateMachine.EEskalatorInteractionState estate) : base(context, estate)
    {
        EskalatorContextState Context = context;
    }
    public override void EnterState()
    {
        EskalatorContext.InGarage.GetCarObject();
    }
    public override void ExitState()
    {
    }
    public override EskalatorInteractionStateMachine.EEskalatorInteractionState GetNextState()
    {
        if (EskalatorContext.InGarage.HasCarObject())
        {
           
            return EskalatorInteractionStateMachine.EEskalatorInteractionState.MoveGarage;
        }
        return StateKey;
    }

    public override void OnTriggerEnter(Collider other)
    {
        Debug.Log("other obj", other.gameObject);
    }

    public override void OnTriggerExit(Collider other)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerStay(Collider other)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {

    }
  
}
