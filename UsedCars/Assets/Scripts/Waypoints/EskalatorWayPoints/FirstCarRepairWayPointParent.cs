using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCarRepairWayPointParent : MonoBehaviour {
    [SerializeField] private List<Transform> _childQueueWayPoint;
    [SerializeField] private Dictionary<EskalatorInteractionStateMachine, int> _eskalatorSTate;
    private int index;


    private void Start() {
        _eskalatorSTate = new Dictionary<EskalatorInteractionStateMachine, int>();
    }

    public Transform GetNExtQueue(EskalatorInteractionStateMachine eskalatorInteractionStateMachine, Transform currentQueue) {
        if (_childQueueWayPoint.Count - 1 > index) {
            currentQueue = _childQueueWayPoint[index];
            _eskalatorSTate.Add(eskalatorInteractionStateMachine, index);
            index++;
            return currentQueue;
        } else {
            return null;
        }
    }
    public void DecrementIndex() {
        index--;
    }
    public Transform GetFreeWayPoint(EskalatorInteractionStateMachine eskalatorInteractionStateMachine, Transform currentQueue) {
        if (_eskalatorSTate.ContainsKey(eskalatorInteractionStateMachine)) {
            _eskalatorSTate.TryGetValue(eskalatorInteractionStateMachine, out var index);
            currentQueue = _childQueueWayPoint[index - 1];
            _eskalatorSTate.Remove(eskalatorInteractionStateMachine);
            _eskalatorSTate.Add(eskalatorInteractionStateMachine, index - 1);
            return currentQueue;
        } else {
            return null;
        }
    }

}
