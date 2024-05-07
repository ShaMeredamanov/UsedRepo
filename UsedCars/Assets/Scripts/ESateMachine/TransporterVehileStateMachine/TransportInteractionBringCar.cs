
using UnityEngine;

public class TransportInteractionBringCar : CarBaseInteractionState
{
    private Transform currentWayPoint;
    private float speed;
    private float distanceThreeShold = 2.5f;
    private Quaternion rotataionGoal;
    private Vector3 directionToWoyPoint;
    private float rotateSpeed = 5f;
    private Transform parentTransfrom;
    private int childCount;
    public TransportInteractionBringCar(TransportCarContextState transportCarContext, TransportIntercationStateMachine.ETransportInteractionState estate) : base(transportCarContext, estate)
    {
        TransportCarContextState transportCarContextState = transportCarContext;
    }
    public override void EnterState()
    {
        currentWayPoint = Context.Waypoints.GetNextWayPoint(currentWayPoint);
        parentTransfrom = Context.Waypoints.GetThisComponentTransfrom(parentTransfrom);
        childCount = parentTransfrom.childCount;
     
        Context.Transporter.GetChildCar();
        speed = Context.GeneralSpeed;
    }
    public override void ExitState()
    {
    }

    public override TransportIntercationStateMachine.ETransportInteractionState GetNextState()
    {
        if (childCount - 1 <= currentWayPoint.GetSiblingIndex())
        {
            return TransportIntercationStateMachine.ETransportInteractionState.GivesAway;
        }
        else
        {
            return StateKey;
        }
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
        var direction = (currentWayPoint.transform.position - Context.BigCar.transform.position).normalized;
        Context.BigCar.transform.Translate(direction * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(Context.BigCar.transform.position, currentWayPoint.position) <= distanceThreeShold)
        {
            currentWayPoint = Context.Waypoints.GetNextWayPoint(currentWayPoint);

        }
        RotateTowardsWayPoint();
    }
    private void RotateTowardsWayPoint()
    {
        directionToWoyPoint = (currentWayPoint.position - Context.BigCar.transform.position).normalized;
        rotataionGoal = Quaternion.LookRotation(directionToWoyPoint);
        Context.BigCar.transform.rotation = Quaternion.Slerp(Context.BigCar.transform.rotation, rotataionGoal, rotateSpeed * Time.deltaTime);
    }
}