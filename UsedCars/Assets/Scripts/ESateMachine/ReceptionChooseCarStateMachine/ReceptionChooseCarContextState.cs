using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceptionChooseCarContextState {
    private ReceptionChooseCarStateMachine _stateMachine;
    private List<PeopleStateMachine> _clientsWalkOutSideList;
    private BoxCollider _boxCollider;
    private List<PeopleStateMachine> _receptionClientsList;
    private Image _image;
    private WaitingQueueParent _waitingQueueParent;
    private SignContractInteractionStateMachine _signContractInteractionStateMachine;
     private Animator _animator;
    private float _upgradePrice;
    public ReceptionChooseCarContextState(ReceptionChooseCarStateMachine receptionChooseCarStateMachine, List<PeopleStateMachine> clients,
        BoxCollider boxCollider, List<PeopleStateMachine> receptionList, Image image, WaitingQueueParent waitingQueueParent, 
        SignContractInteractionStateMachine signContractInteractionStateMachine, Animator animator, float upgradePrice) {

        _stateMachine = receptionChooseCarStateMachine;
        _clientsWalkOutSideList = clients;
        _boxCollider = boxCollider;
        _receptionClientsList = receptionList;
        _image = image;
        _waitingQueueParent = waitingQueueParent;
        _signContractInteractionStateMachine = signContractInteractionStateMachine;
        _animator = animator;
        _upgradePrice = upgradePrice;


    }
    public ReceptionChooseCarStateMachine ReceptionChooseCarStateMachine => _stateMachine;
    public List<PeopleStateMachine> ClientsWalkOutSideList => _clientsWalkOutSideList;
    public BoxCollider BoxCollider => _boxCollider;
    public List<PeopleStateMachine> ReceptionClientsList => _receptionClientsList;
    public Image Image => _image;
    public WaitingQueueParent WaitingQueueParent => _waitingQueueParent;
    public SignContractInteractionStateMachine SignContractInteractionStateMachine => _signContractInteractionStateMachine;
    public  Animator Animator => _animator;
    public float UpgradePrice => _upgradePrice;
}
