using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHM_WaitingQueue_GuestAI{
    private enum State {
        GoingEntrancePosition,
        WaitingInMiddleOfQueue,
    }
    private Guest guest;
    private SHM_WaitingQueue _waitingQueue;
    private State _state;
    public SHM_WaitingQueue_GuestAI(SHM_WaitingQueue _waitingQueue, Guest guest, Vector3 entrancePosition) {
        this.guest = guest;
        this._waitingQueue = _waitingQueue;
        _state = State.GoingEntrancePosition;
        guest.MoveTo(entrancePosition, () => {
            _state = State.WaitingInMiddleOfQueue;
            _waitingQueue.GuestRequestSetQueuePosition(this);
        });
    }
    public void SetQueuePosition(Vector3 position){
        guest.MoveTo(position, () => { _waitingQueue.GuestRequestSetQueuePosition(this); 
        }) ;
    }
    public bool IsWaitingInMiddleOfQueue() {
        return _state == State.WaitingInMiddleOfQueue;
    }
    public Guest GetGuest() {
        return guest;
    }
}