using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstRepairShopContext {
    private List<EskalatorInteractionStateMachine> _eskalatorInteractionStateMachinesList;
    private TransporterInGarage _transporterInGarage;
    private SecondRepairShop _secondRepairShop;
    private FirstRepairShopInteractionStateMachine _firstRepairShopInteractionStateMachine;
    private Image _image;
    private ParticleSystem _particleSystem;
    private Animator _animator;
    private SecondWashShopStateMachine _secondWashShopStateMachine;
    private Animator _workerAnimator;
    private Image _outLine;
    public FirstRepairShopContext(List<EskalatorInteractionStateMachine> eskalatorInteractionStateMachines, TransporterInGarage transporterInGarage, 
        SecondRepairShop secondRepairShop, FirstRepairShopInteractionStateMachine firstRepairShopInteractionStateMachine, 
        Image image, ParticleSystem particleSystem, Animator animator, SecondWashShopStateMachine secondWashShopStateMachine, 
        Animator workerAnimator, Image outLine ) {
        _eskalatorInteractionStateMachinesList = eskalatorInteractionStateMachines;
        _transporterInGarage = transporterInGarage;
        _secondRepairShop = secondRepairShop;
        _firstRepairShopInteractionStateMachine = firstRepairShopInteractionStateMachine;
        _image = image;
        _particleSystem = particleSystem;
        _animator = animator;
        _secondWashShopStateMachine = secondWashShopStateMachine;
        _workerAnimator = workerAnimator;
        _outLine = outLine; 
    }
    public List<EskalatorInteractionStateMachine> EskalatorInteractionStateMachinesList => _eskalatorInteractionStateMachinesList;  
    public TransporterInGarage TransporterInGarage => _transporterInGarage;
    public SecondRepairShop SecondRepairShop => _secondRepairShop;  
    public FirstRepairShopInteractionStateMachine FirstRepairShopInteractionStateMachine => _firstRepairShopInteractionStateMachine;
    public Image Image => _image;
    public ParticleSystem ParticleSystem => _particleSystem;
    public Animator Animator => _animator;  
    public SecondWashShopStateMachine SecondWashShopStateMachine => _secondWashShopStateMachine;
    public Animator WorkerAnimator => _workerAnimator;
    public Image OutLine => _outLine;
}