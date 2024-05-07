using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignContractContextState {
    private SignContractInteractionStateMachine _signContractInteractionStateMachine;
    private List<PeopleStateMachine> _peopleStateMachinesList;
    private List<EskalatorInteractionStateMachine> _eskalatorInteractionStateMachinesList;
    private WaitingQueueParent _waitingQueueParent;
    private Image _image;
    private UiCanvas _uiCanvas;
    private Animator _workerAnimator;
    private List<GameObject> _moneyObjectList;
    private Image _moneyInScene;
    public SignContractContextState(SignContractInteractionStateMachine signContractInteractionStateMachine,
        List<PeopleStateMachine> peopleStateMachines, List<EskalatorInteractionStateMachine> eskalatorInteractionStateMachines, 
        WaitingQueueParent waitingQueueParent, Image image, UiCanvas canvas, Animator workerAnimator, List<GameObject> moneyObjectList, Image moneyInScene) {
        _signContractInteractionStateMachine = signContractInteractionStateMachine;
        _peopleStateMachinesList = peopleStateMachines;
        _eskalatorInteractionStateMachinesList = eskalatorInteractionStateMachines;
        _waitingQueueParent = waitingQueueParent;
        _image = image;
        _uiCanvas = canvas;
        _workerAnimator = workerAnimator;
        _moneyObjectList = moneyObjectList;
        _moneyInScene = moneyInScene;

    }
    /// <summary>
    /// Read only properties
    /// </summary>
    public SignContractInteractionStateMachine SignContractInteractionStateMachine => _signContractInteractionStateMachine;
    public List<PeopleStateMachine> PeopleStateMachinesList => _peopleStateMachinesList;
    public List<EskalatorInteractionStateMachine> EskalatorInteractionStateMachinesList => _eskalatorInteractionStateMachinesList;
    public WaitingQueueParent WaitingQueueParent => _waitingQueueParent;

    public Image Image => _image;
    public UiCanvas Canvas => _uiCanvas;
    public Animator WorkerAnimator => _workerAnimator;
    public List<GameObject> MoneyObjectList => _moneyObjectList;
    public Image MoneyInScene => _moneyInScene;
}