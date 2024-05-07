using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdWayPointParentForQueue : MonoBehaviour {
    [SerializeField] private List<Transform> _childTransform;
    [SerializeField] private Dictionary<EskalatorInteractionStateMachine, int> _statesInQueue;
    private int index;
    private void Start() {
        _statesInQueue = new Dictionary<EskalatorInteractionStateMachine, int>();
    }
    public Transform GetNExtQueue(EskalatorInteractionStateMachine eskalatorInteractionState, Transform currentTransform) {
        if (_childTransform.Count - 1 > index) {
            currentTransform = _childTransform[index];
            _statesInQueue.Add(eskalatorInteractionState, index);
            index++;
            return currentTransform;
        } else {
            return null;
        }
    }
    public Transform GetFreeWayPoint(EskalatorInteractionStateMachine eskalatorInteractionStateMachine, Transform currentQueue) {
        if (_statesInQueue.ContainsKey(eskalatorInteractionStateMachine)) {
            _statesInQueue.TryGetValue(eskalatorInteractionStateMachine, out var index);
            currentQueue = _childTransform[index - 1];
            _statesInQueue.Remove(eskalatorInteractionStateMachine);
            _statesInQueue.Add(eskalatorInteractionStateMachine, index - 1);
            return currentQueue;
        } else {
            return null;
        }
    }
    public void DecrementIndex() {
        index--;
    }
    public int Index => index;
}
