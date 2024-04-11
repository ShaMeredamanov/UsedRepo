using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using System;
public class SHM_WaitingQueue {
    public event EventHandler OnGuestArrivedAtFrontOfQueue;
    private List<Vector3> _positionList;
    private Vector3 entrancePosition;
    private List<SHM_WaitingQueue_GuestAI> guestAiList;
    public SHM_WaitingQueue(List<Vector3> positionList) {
        _positionList = positionList;
        entrancePosition = positionList[positionList.Count - 1] + new Vector3(-8f, 0f);
        foreach (Vector3 position in positionList) {
            World_Sprite.Create(position, new Vector3(.3f, .3f, .3f), Color.red);
        }
        World_Sprite.Create(entrancePosition, new Vector3(1, 1), Color.magenta);
        guestAiList = new List<SHM_WaitingQueue_GuestAI>();
    }
    public bool CanAddGuest() {
        return guestAiList.Count < _positionList.Count;
    }
    public void AddGuest(Guest guest) {
        SHM_WaitingQueue_GuestAI sHM_WaitingQueue_GuestAI = new SHM_WaitingQueue_GuestAI(this, guest, entrancePosition);
        guestAiList.Add(sHM_WaitingQueue_GuestAI);
    }
    public void GuestRequestSetQueuePosition(SHM_WaitingQueue_GuestAI guestAI) {
        for (int i = 0; i < guestAiList.Count; i++) {
            if (guestAiList[i] == guestAI) {
                break;
            } else {
                if (!guestAiList[i].IsWaitingInMiddleOfQueue()) {
                    guestAiList[guestAiList.IndexOf(guestAI)] = guestAiList[i];
                    guestAiList[i] = guestAI;
                }
            }
        }
            guestAI.SetQueuePosition(_positionList[guestAiList.IndexOf(guestAI)]);
    }
    public Guest GetFirstInQueue() {
        if (guestAiList.Count == 0) {
            return null;
        } else {
            Guest guest = guestAiList[0].GetGuest();
            guestAiList.RemoveAt(0);
            RelocateAllGuest();
            return guest;
        }
    }
    public void RelocateAllGuest() {

        for (int i = 0; i < guestAiList.Count; i++) {
            SHM_WaitingQueue_GuestAI guestAI = guestAiList[i];
            if (guestAI.IsWaitingInMiddleOfQueue()) {
                guestAI.SetQueuePosition(_positionList[guestAiList.IndexOf(guestAI)]);
            }
        }
    }
    public void GuestArrivedAtQueuePosition(SHM_WaitingQueue_GuestAI guestAI) {
        if (guestAI == guestAiList[0]) {
            if (OnGuestArrivedAtFrontOfQueue != null) OnGuestArrivedAtFrontOfQueue(this, EventArgs.Empty);
        }
    }
}

