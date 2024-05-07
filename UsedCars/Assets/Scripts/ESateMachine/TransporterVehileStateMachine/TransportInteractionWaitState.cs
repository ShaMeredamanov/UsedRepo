
using UnityEngine;

public class TransportInteractionWaitState : CarBaseInteractionState
{
    private float timer = 3;
    private float timerMax = 3;
    private Transform convierObject;
    private ITransportParent transportParent;
    public TransportInteractionWaitState(TransportCarContextState transportCarContext, TransportIntercationStateMachine.ETransportInteractionState estate) : base(transportCarContext, estate)
    {
        TransportCarContextState transportCarContextState = transportCarContext;

    }
    public override void EnterState()
     {
        transportParent = Context.BigCar.GetConveir();
        Context.Transporter.GetCarObject().SetUsedCars(transportParent);
        transportParent.SetCarObject(transportParent);
    }

    public override void ExitState()
    {
    }

    public override TransportIntercationStateMachine.ETransportInteractionState GetNextState()
    {
        if (transportParent.HasCarObject())
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = timerMax;
                return TransportIntercationStateMachine.ETransportInteractionState.TurnBack;
            }
        }
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
