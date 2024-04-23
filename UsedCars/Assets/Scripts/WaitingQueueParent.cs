using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WaitingQueueParent : MonoBehaviour {
    [SerializeField] private List<Transform> _childrensTransform;
    [SerializeField] private List<PeopleStateMachine> _peopleStateMachine;
    [SerializeField] private Dictionary<PeopleStateMachine, int> _peopleStates;
    private int index;
    private void Start() {
        _peopleStates = new Dictionary<PeopleStateMachine, int>();
    }
    public void GetPeopleStateMachineList(PeopleStateMachine peopleStateMachine) {
        _peopleStateMachine.Add(peopleStateMachine);
    }
    public Transform GetCurrentQueue(Transform childTarnsform, PeopleStateMachine peopleStateMachine) {
        if (_childrensTransform.Count - 1 > index) {
            childTarnsform = _childrensTransform[index];
            GetPeopleStateMachineList(peopleStateMachine);
            _peopleStates.Add(peopleStateMachine, index);
            index++;
            return childTarnsform;
        } else {
            return null;
        }
    }
    public Transform GetWayPoint(PeopleStateMachine peopleStateMachine, Transform current) {
        if (_peopleStates.ContainsKey(peopleStateMachine)) {
            _peopleStates.TryGetValue(peopleStateMachine, out var wayPoint);
            current = _childrensTransform[wayPoint - 1];
            _peopleStates.Remove(peopleStateMachine);
            _peopleStates.Add(peopleStateMachine, index - 1);
            return current;
        } else {
            return null;
        }
    }
    public void DecrementIndex() {
        _peopleStateMachine.RemoveAt(0);
        index--;
    }
    public List<Transform> ChildrensTransforms => _childrensTransform;
    public int Index => index;
}
