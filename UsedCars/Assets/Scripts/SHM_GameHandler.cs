using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;
public class SHM_GameHandler : MonoBehaviour {
    [SerializeField] private List<Guest> guestList;
    private SHM_WaitingQueue waitingQueue;

    void Start() {
        List<Vector3> waitingQueuePositionList = new List<Vector3>();
        Vector3 firstPosition = new Vector3(115.077f, -2.3f, -35.93f);
        float positionSize = 8f;
        for (int i = 0; i < 5; i++) {
            waitingQueuePositionList.Add(firstPosition + new Vector3(-1, 0) * positionSize * i);
        }
        waitingQueue = new SHM_WaitingQueue(waitingQueuePositionList);

         CMDebug.ButtonUI(new Vector3(200, 200, 200), "Get guest", () => {
              Guest guest = waitingQueue.GetFirstInQueue();
              if (guest != null) {
                  guest.MoveTo(firstPosition + new Vector3(500, 0));
              }
          });
        FunctionPeriodic.Create(() => {
            if (waitingQueue.CanAddGuest()) {
                var numberGuest = Random.Range(0, 3);
                waitingQueue.AddGuest(guestList[numberGuest]);
                guestList.RemoveAt(numberGuest);
                CMDebug.TextPopup("AddGuest", new Vector3(116f, 5f, -15f));
            }
        }, 1f);
        waitingQueue.OnGuestArrivedAtFrontOfQueue += WaitingQueue_OnGuestArrivedAtFrontOfQueue;
    }

    private void WaitingQueue_OnGuestArrivedAtFrontOfQueue(object sender, System.EventArgs e) {
        CMDebug.TextPopup("OnGuestArrivedAtQueue", new Vector3(116.416f, 6.606833f, -29.26249f));
        FunctionTimer.Create(() => {
            Guest guest = waitingQueue.GetFirstInQueue();
            if (guest != null) {
                guest.MoveTo(new Vector3(115.077f, -2.3f, -35.93f) + new Vector3(500, 0));
            }
        }, 1f);
    }
    public void AddGuest() {
        var numberGuest = Random.Range(0, 3);
        waitingQueue.AddGuest(guestList[numberGuest]);
        guestList.RemoveAt(numberGuest);
    }
}
