using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondWashShopContextState {
    private List<EskalatorInteractionStateMachine> _eskalatorInteractionStateMachines;
    private SecondWashShopStateMachine _secondWashShopStateMachine;
    private FirstRepairShopInteractionStateMachine _firstRepairShopInteractionStateMachine;
    private SecondReceptionSignContract _seconReseptionSignContract;
    private ThirdWayPointParentForQueue _thirdWayPointParentForQueue;
    private SignContractInteractionStateMachine _signContractInteractionStateMachine;
    private Image _image;
    private ParticleSystem _particleSystem;
    private ParticleSystem _particleSystemSecond;
    private Animator _animator;
    private ParticleSystem _bubbleShower;
    private Animator _wrokerAnimator;
    private Image _outLine;
    public SecondWashShopContextState(List<EskalatorInteractionStateMachine> eskalatorInteractionStateMachines,
        SecondWashShopStateMachine secondWashShopStateMachine, FirstRepairShopInteractionStateMachine firstRepairShopInteractionStateMachine,
        SecondReceptionSignContract seconReseptionSignContract, ThirdWayPointParentForQueue thirdWayPointParentForQueue, Image image, 
        ParticleSystem particleSystem, ParticleSystem particleSystem1, Animator animator, SignContractInteractionStateMachine signContractInteractionState, 
        ParticleSystem bubbleShower, Animator wrokerAnimator, Image outLine ) {
        _eskalatorInteractionStateMachines = eskalatorInteractionStateMachines;
        _secondWashShopStateMachine = secondWashShopStateMachine;
        _firstRepairShopInteractionStateMachine = firstRepairShopInteractionStateMachine;
        _seconReseptionSignContract = seconReseptionSignContract;
        _thirdWayPointParentForQueue = thirdWayPointParentForQueue;
        _image = image;
        _particleSystem = particleSystem;
        _animator = animator;
        _particleSystemSecond = particleSystem1;
        _signContractInteractionStateMachine = signContractInteractionState;
        _bubbleShower = bubbleShower;
        _wrokerAnimator = wrokerAnimator;
        _outLine = outLine;
    }

    public List<EskalatorInteractionStateMachine> EskalatorInteractionStateMachines => _eskalatorInteractionStateMachines;
    public SecondWashShopStateMachine SecondWashShopStateMachine => _secondWashShopStateMachine;
    public FirstRepairShopInteractionStateMachine FirstRepairShopInteractionStateMachine => _firstRepairShopInteractionStateMachine;
    public SecondReceptionSignContract SecondReceptionSignContract => _seconReseptionSignContract;
    public ThirdWayPointParentForQueue ThirdWayPointParentForQueue => _thirdWayPointParentForQueue;
    public Image Image => _image;   
   public ParticleSystem ParticleSystem => _particleSystem;
    public Animator Animator => _animator;
    public ParticleSystem ParticleSystemSecond => _particleSystemSecond;
    public SignContractInteractionStateMachine SignContractInteractionStateMachines => _signContractInteractionStateMachine;
  public ParticleSystem BubbleShower => _bubbleShower;
    public Animator WorkerAnimator => _wrokerAnimator;
    public Image OutLine => _outLine;
  }