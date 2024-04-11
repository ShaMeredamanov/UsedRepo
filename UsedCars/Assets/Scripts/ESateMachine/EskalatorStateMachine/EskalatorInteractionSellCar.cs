using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EskalatorInteractionSellCar : EskalatorBaseIteractionState
{
    public EskalatorInteractionSellCar(EskalatorContextState context, EskalatorInteractionStateMachine.EEskalatorInteractionState estate) : base(context, estate)
    {
        EskalatorContextState Context = context;
    }

    public override void EnterState()
    {

    }

    public override void ExitState()
    {
    }

    public override EskalatorInteractionStateMachine.EEskalatorInteractionState GetNextState()
    {
        return StateKey;
    }

    public override void OnTriggerEnter(Collider other)
    {
        throw new System.NotImplementedException();
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
