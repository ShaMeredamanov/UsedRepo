using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingQueueParent : MonoBehaviour {
    [SerializeField] private List<Transform> _childrensTransform;
    private List<PeopleStateMachine> _peopleStateMachine;
    private int index;
    public void GetPeopleStateMachineList(PeopleStateMachine peopleStateMachine) {
        _peopleStateMachine.Add(peopleStateMachine);
    }
    public void GetCurrentQueue(Transform childTarnsform) {
        if (_childrensTransform.Count - 1 > index) {
            childTarnsform = _childrensTransform[index];
            index++;
        }
    }
}
